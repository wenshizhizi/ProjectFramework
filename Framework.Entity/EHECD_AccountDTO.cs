using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_Account")]
    public class EHECD_AccountDTO
    {

        /// <summary>
        /// 主键
        /// </summary>
        [FieldInfo(DataFieldLength = 16, FiledName = "ID", Required = true)]
        public Guid? ID
        {
            get; set;
        }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [FieldInfo(DataFieldLength = 20, FiledName = "sRealName", Required = true)]
        public String sRealName
        {
            get; set;
        }

        /// <summary>
        /// 登录名
        /// </summary>
        [FieldInfo(DataFieldLength = 12, FiledName = "sLoginName", Required = true)]
        public String sLoginName
        {
            get; set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        [FieldInfo(DataFieldLength = 50, FiledName = "sLoginPwd", Required = true)]
        public String sLoginPwd
        {
            get; set;
        }

        /// <summary>
        /// 类型（0-公司员工 1-管理员）
        /// </summary>
        [FieldInfo(DataFieldLength = 4, FiledName = "iType", Required = true)]
        public Int32? iType
        {
            get; set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [FieldInfo(DataFieldLength = 8, FiledName = "dCreateTime", Required = true)]
        public DateTime? dCreateTime
        {
            get; set;
        }

        /// <summary>
        /// 是否删除（0-否 1-是）
        /// </summary>
        [FieldInfo(DataFieldLength = 1, FiledName = "bIsDeleted", Required = true)]
        public Boolean? bIsDeleted
        {
            get; set;
        }

        /// <summary>
        /// 排序
        /// </summary>
        [FieldInfo(DataFieldLength = 4, FiledName = "iOrder", Required = true)]
        public Int32? iOrder
        {
            get; set;
        }
    }
}
