using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PDTech.OA.OCR
{
    class Program
    {
        public readonly static log4net.ILog Logger = log4net.LogManager.GetLogger("testApp.Logging");
        static void Main(string[] args)
        {
            try
            {
                log4net.Config.DOMConfigurator.Configure(new FileInfo("PDTech.OA.OCR.vshost.exe.Config"));
                log4net.GlobalContext.Properties["pid"] = System.Diagnostics.Process.GetCurrentProcess().Id;
                Logger.Info("Application Start");
                Process instance = RunningInstance();
                if (instance == null)
                {
                    OCRServices ocr = new OCRServices();
                    ocr.ProcessOCR();
                }
                else
                {
                    Logger.Info("另一进程运行中");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("未处理异常", ex);
            }
        }

        /// <summary> 
        /// 获取正在运行的进程实例         
        /// </summary> 
        /// <returns></returns> 
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess(); Process[] processes = Process.GetProcessesByName(current.ProcessName);             //循环所有进程    
            foreach (Process process in processes)
            {
                //忽略当前进程 
                if (process.Id != current.Id)
                {
                    //确保当前进程是从本Exe启动的进程                       
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //返回其他进程实例                         
                        return process;
                    }
                }
            }
            //如果没有其他同名进程存在，则返回NULL              
            return null;
        }
    }
}
