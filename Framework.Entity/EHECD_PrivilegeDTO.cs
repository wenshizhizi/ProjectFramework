using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_Privilege")]
    public class EHECD_PrivilegeDTO
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
        /// 特权所有人标识
        /// 可根据此标识进行分组
        /// 如，这个特权是给角色的，那么这个字段可以表示为Role
        /// 这个特权是分配个用户的，那么这个字段可以表示为User
        /// </summary>
        [FieldInfo(DataFieldLength = 15,FiledName = "sPrivilegeMaster",Required = true)]
        public String sPrivilegeMaster
        {
            get; set;
        }

        /// <summary>
        /// 对应的特权所有人的唯一标识
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "sPrivilegeMasterValue",Required = true)]
        public Guid? sPrivilegeMasterValue
        {
            get; set;
        }

        /// <summary>
        /// 访问权限的标识，用来对访问者所拥有的权限进行标识区分
        /// 比如：
        /// 这是一个菜单权限，则这里可以用Menu来标识
        /// 这是一个按钮权限，则这里可以用Button来标识
        /// </summary>
        [FieldInfo(DataFieldLength = 15,FiledName = "sPrivilegeAccess",Required = true)]
        public String sPrivilegeAccess
        {
            get; set;
        }

        /// <summary>
        /// 对应的权限
        /// 如
        /// 对应的菜单ID
        /// 对应的按钮ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "sPrivilegeAccessValue",Required = true)]
        public Guid? sPrivilegeAccessValue
        {
            get; set;
        }

        /// <summary>
        /// 是否要禁用该特权
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "sPrivilegeOperation",Required = true)]
        public Boolean? sPrivilegeOperation
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
