using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_SystemUser_R_Role")]
    public class EHECD_SystemUser_R_RoleDTO
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
        /// 用户的ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "sUserID",Required = true)]
        public Guid? sUserID
        {
            get; set;
        }

        /// <summary>
        /// 角色的ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "sRoleID",Required = true)]
        public Guid? sRoleID
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
    }
}
