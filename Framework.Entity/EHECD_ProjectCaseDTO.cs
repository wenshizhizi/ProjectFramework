using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    /// <summary>
    /// 项目案列DTO
    /// </summary>
    public class EHECD_ProjectCaseDTO
    {

        /// <summary>
        /// ID
        /// </summary>		
        public Guid? ID
        {
            get; set;
        }
        /// <summary>
        /// 项目名称
        /// </summary>		
        public string sProjectName
        {
            get; set;
        }
        /// <summary>
        /// 项目类型
        /// </summary>		
        public int? iProjectType
        {
            get; set;
        }
        /// <summary>
        /// 项目排序
        /// </summary>		
        public int? iOrder
        {
            get; set;
        }
        /// <summary>
        /// 项目导图
        /// </summary>		
        public string sProjectPicture
        {
            get; set;
        }
        /// <summary>
        /// 项目详情
        /// </summary>		
        public string sProjectDetail
        {
            get; set;
        }
        /// <summary>
        /// 逻辑删除标志
        /// </summary>		
        public bool? bIsDeleted
        {
            get; set;
        }

    }
}