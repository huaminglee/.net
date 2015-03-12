using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDTech.OA.OCR
{
    public class OCRServices
    {
        public void ProcessOCR()
        {
            PDTech.OA.BLL.OA_ATTACHMENT_FILE attFileBll = new PDTech.OA.BLL.OA_ATTACHMENT_FILE();
            string _webServerPath = ConfigurationManager.AppSettings["ServerPath"];  
            string _fileTypes = ConfigurationManager.AppSettings["FileTypes"];  
            while (true)
            {
                IList<PDTech.OA.Model.OA_ATTACHMENT_FILE> files = attFileBll.get_InfoList(100, "AND OCR_STATUS =0");//获取待发消息
                if (files == null || files.Count == 0)
                {
                    Program.Logger.Info("所有附件已OCR处理完成!");
                    break;
                }
                List<string> processedFiles = new List<string>();
                foreach (var item in files)
                {
                    if (processedFiles.Exists(i => i == item.FILE_PATH))
                    {
                        Program.Logger.Info("文件：《" + item.FILE_PATH + "》已处理！");
                    }
                    else
                    {
                        try
                        {
                            processedFiles.Add(item.FILE_PATH);
                            string fileName = _webServerPath + "\\" + item.FILE_PATH.TrimStart("/".ToCharArray()).Replace("\\\\","\\");
                            if (File.Exists(fileName))
                            {
                                if (_fileTypes.Contains(item.FILE_TYPE.ToUpper()))
                                {
                                    MODI.Document _MODIDocument = new MODI.Document();
                                    _MODIDocument.Create(fileName);
                                    _MODIDocument.OCR(MODI.MiLANGUAGES.miLANG_CHINESE_SIMPLIFIED, true, true);
                                    string ss = (_MODIDocument.Images[0] as MODI.Image).Layout.Text;
                                    item.OCR_CONTENT = ss;
                                    item.OCR_STATUS = 1;
                                    _MODIDocument.Close(false);
                                    _MODIDocument = null;
                                }
                                else
                                {
                                    Program.Logger.Warn("文件：《" + fileName + "》跳过！");
                                    item.OCR_CONTENT = null;
                                    item.OCR_STATUS = 1;
                                }
                            }
                            else
                            {
                                Program.Logger.Warn("文件：《" + fileName + "》不存在！");
                                item.OCR_CONTENT = null;
                                item.OCR_STATUS = 9;
                            }
                        }
                        catch (Exception ex)
                        {
                            Program.Logger.Error("文件：《" + item.FILE_PATH + "》处理出错！", ex);
                            item.OCR_CONTENT = null;
                            item.OCR_STATUS = 9;
                        }
                        attFileBll.UpdateOCRInfo(item);
                    }
                }
            }
        }
    }
}
