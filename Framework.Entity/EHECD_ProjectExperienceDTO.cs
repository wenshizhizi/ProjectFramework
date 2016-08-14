using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{   
    /// <summary>
    /// 项目体验DTO
    /// </summary>
    public class EHECD_ProjectExperienceDTO
    {

        /// <summary>
        /// 主键ID
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
        /// 项目排序
        /// </summary>		
        public int? iOrder
        {
            get; set;
        }
        /// <summary>
        /// 项目图标
        /// </summary>		
        public string sProjectIcon
        {
            get; set;
        }
        /// <summary>
        /// 项目部署地址
        /// </summary>		
        public string sProjectAddress
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