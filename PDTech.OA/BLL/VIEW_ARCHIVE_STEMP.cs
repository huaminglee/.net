using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PDTech.OA.Model;

namespace PDTech.OA.BLL
{
    public class VIEW_ARCHIVE_STEMP
    {
        private readonly PDTech.OA.DAL.VIEW_ARCHIVE_STEMP dal = new PDTech.OA.DAL.VIEW_ARCHIVE_STEMP();
        public VIEW_ARCHIVE_STEMP()
        { }
        
        /// <summary>
        /// 获取公文相关信息列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<Model.VIEW.VIEW_ARCHIVE_STEMP> get_ViewArchiveStep(Model.VIEW.VIEW_ARCHIVE_STEMP where)
        {
            return dal.get_ViewArchiveStep(where);
        }

        /// <summary>
        /// 获取公文相关信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Model.VIEW.VIEW_ARCHIVE_STEMP get_viewarchivestepInfo(Model.VIEW.VIEW_ARCHIVE_STEMP where)
        {
            return dal.get_viewarchivestepInfo(where);
        }

    }
}
