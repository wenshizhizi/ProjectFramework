using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_Role")]
    public class EHECD_RoleDTO
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
        /// 角色名称
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sRoleName",Required = true)]
        public String sRoleName
        {
            get; set;
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "bEnable",Required = true)]
        public Boolean? bEnable
        {
            get; set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        [FieldInfo(DataFieldLength = 8,FiledName = "dCreateTime",Required = true)]
        public DateTime? dCreateTime
        {
            get; set;
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        [FieldInfo(DataFieldLength = 8,FiledName = "dModifyTime",Required = true)]
        public DateTime? dModifyTime
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
        /// 排序编号
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "iOrder",Required = true)]
        public Int32? iOrder
        {
            get; set;
        }
    }
}
