using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_FunctionMenu")]
    public class EHECD_FunctionMenuDTO
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
        /// 菜单名称
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sMenuName",Required = true)]
        public String sMenuName
        {
            get; set;
        }

        /// <summary>
        /// 上级菜单标识
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "sPID",Required = false)]
        public Guid? sPID
        {
            get; set;
        }

        /// <summary>
        /// 对应链接地址
        /// </summary>
        [FieldInfo(DataFieldLength = 50,FiledName = "sUrl",Required = true)]
        public String sUrl
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
