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
        [FieldInfo(DataFieldLength = 16, FiledName = "ID", Required = true)]
        public Guid? ID
        {
            get; set;
        }

        /// <summary>
        /// 配置该特权所属的对象
        ///
        ///如，
        ///
        ///这个特权是属于角色的，那么这个字段表示为role
        ///这个特权是属于用户的，那么这个字段表示为user
        /// </summary>
        [FieldInfo(DataFieldLength = 15, FiledName = "sPrivilegeMaster", Required = true)]
        public String sPrivilegeMaster
        {
            get; set;
        }

        /// <summary>
        /// 对应的特权所有者的唯一标识
        ///如特权所有者是role
        ///则该字段就是记录的对应的特权所有者的ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16, FiledName = "sPrivilegeMasterValue", Required = true)]
        public Guid? sPrivilegeMasterValue
        {
            get; set;
        }

        /// <summary>
        /// 特权类型标识
        ///该字段标识了这个特权的类型
        ///比如：
        ///这是一个菜单特权，则这里用menu来标识
        ///这是一个按钮特权，则这里用button来标识
        /// </summary>
        [FieldInfo(DataFieldLength = 15, FiledName = "sPrivilegeAccess", Required = true)]
        public String sPrivilegeAccess
        {
            get; set;
        }

        /// <summary>
        /// 对应的特权
        ///如
        ///对应的菜单ID
        ///对应的按钮ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16, FiledName = "sPrivilegeAccessValue", Required = true)]
        public Guid? sPrivilegeAccessValue
        {
            get; set;
        }

        /// <summary>
        /// 标识这个特权所有者的类型
        ///与特权所属对象对应，以指定这个特权所属的类型
        ///如，该特权是赋予用户的，则用user来标识
        ///如，该特权是赋予角色的，则用role来标识
        /// </summary>
        [FieldInfo(DataFieldLength = 15, FiledName = "sBelong", Required = true)]
        public String sBelong
        {
            get; set;
        }

        /// <summary>
        /// 标识这个特权是属于哪个的
        /// </summary>
        [FieldInfo(DataFieldLength = 16, FiledName = "sBelongValue", Required = true)]
        public Guid? sBelongValue
        {
            get; set;
        }

        /// <summary>
        /// 是否要禁用该特权 0为不禁用 1为禁用
        /// </summary>
        [FieldInfo(DataFieldLength = 1, FiledName = "bPrivilegeOperation", Required = true)]
        public Boolean? bPrivilegeOperation
        {
            get; set;
        }

        /// <summary>
        /// 是否删除 0 未删除 1删除
        /// </summary>
        [FieldInfo(DataFieldLength = 1, FiledName = "bIsDeleted", Required = true)]
        public Boolean? bIsDeleted
        {
            get; set;
        }
    }
}
