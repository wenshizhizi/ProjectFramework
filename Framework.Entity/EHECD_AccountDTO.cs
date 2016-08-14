using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    /// <summary>
    /// 用户DTO
    /// </summary>
    [Serializable]
    public class EHECD_AccountDTO
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public Guid? ID
        {
            get; set;
        }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string sRealName
        {
            get; set;
        }
        /// <summary>
        /// 登录名
        /// </summary>		
        public string sLoginName
        {
            get; set;
        }
        /// <summary>
        /// 密码
        /// </summary>		
        public string sLoginPwd
        {
            get; set;
        }
        /// <summary>
        /// 类型（0-公司员工 1-管理员）
        /// </summary>		
        public int? iType
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
        /// <summary>
        /// 排序
        /// </summary>		
        public int? iOrder
        {
            get; set;
        }

    }
}