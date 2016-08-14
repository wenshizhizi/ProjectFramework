using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    /// <summary>
    /// 图片DTO
    /// </summary>
    public class EHECD_ImagesDTO
    {

        /// <summary>
        /// 主键
        /// </summary>		
        public Guid? ID
        {
            get; set;
        }
        /// <summary>
        /// 图片路径
        /// </summary>		
        public string sImagePath
        {
            get; set;
        }
        /// <summary>
        /// 图片类型（0-首页Banner图 1-首页下方展示图 2-公司简介轮播图 3-页面展示）
        /// </summary>		
        public int? iType
        {
            get; set;
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public int? iOrder
        {
            get; set;
        }
        /// <summary>
        /// 链接
        /// </summary>		
        public string sLink
        {
            get; set;
        }
        /// <summary>
        /// 是否显示（0-否 1-是）
        /// </summary>		
        public bool? bIsShow
        {
            get; set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime? dCreateTime
        {
            get; set;
        }
        /// <summary>
        /// 是否删除（0-否 1-是）
        /// </summary>		
        public bool? bIsDeleted
        {
            get; set;
        }

    }
}