using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_SystemLog")]
    public class EHECD_SystemLogDTO
    {

        /// <summary>
        /// 唯一标识
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "ID",Required = true)]
        public Guid? ID
        {
            get; set;
        }

        /// <summary>
        /// 操作内容
        /// </summary>
        [FieldInfo(DataFieldLength = 100,FiledName = "sDomainDetail",Required = true)]
        public String sDomainDetail
        {
            get; set;
        }

        /// <summary>
        /// 登录名
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sLoginName",Required = true)]
        public String sLoginName
        {
            get; set;
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [FieldInfo(DataFieldLength = 15,FiledName = "sUserName",Required = true)]
        public String sUserName
        {
            get; set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [FieldInfo(DataFieldLength = 8,FiledName = "dInsertTime",Required = true)]
        public DateTime? dInsertTime
        {
            get; set;
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "bIsDeleted",Required = true)]
        public Boolean? bIsDeleted
        {
            get; set;
        }

        /// <summary>
        /// 登录IP地址
        /// </summary>
        [FieldInfo(DataFieldLength = 25,FiledName = "sIPAddress",Required = true)]
        public String sIPAddress
        {
            get; set;
        }

        /// <summary>
        /// 操作的ID
        /// </summary>
        [FieldInfo(DataFieldLength = 255,FiledName = "sDoMainId",Required = true)]
        public String sDoMainId
        {
            get; set;
        }

        /// <summary>
        /// 操作类型 short
        /// </summary>
        [FieldInfo(DataFieldLength = 2,FiledName = "tDoType",Required = true)]
        public Int16? tDoType
        {
            get; set;
        }
    }
}
