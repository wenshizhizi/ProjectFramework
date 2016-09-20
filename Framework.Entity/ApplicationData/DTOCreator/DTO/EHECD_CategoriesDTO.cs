using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_Categories")]
    public class EHECD_CategoriesDTO
    {

        /// <summary>
        /// 上级ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "PID",Required = false)]
        public Guid? PID
        {
            get; set;
        }

        /// <summary>
        /// 商品种类名
        /// </summary>
        [FieldInfo(DataFieldLength = 255,FiledName = "sCategoryName",Required = true)]
        public String sCategoryName
        {
            get; set;
        }

        /// <summary>
        /// 商品种类简述
        /// </summary>
        [FieldInfo(DataFieldLength = 255,FiledName = "sCategoryCaption",Required = true)]
        public String sCategoryCaption
        {
            get; set;
        }

        /// <summary>
        /// 排序
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "iOrder",Required = true)]
        public Int32? iOrder
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
        /// 创建时间
        /// </summary>
        [FieldInfo(DataFieldLength = 8,FiledName = "dInsertTime",Required = true)]
        public DateTime? dInsertTime
        {
            get; set;
        }

        /// <summary>
        /// 分类图片
        /// </summary>
        [FieldInfo(DataFieldLength = -1,FiledName = "sImgUri",Required = true)]
        public String sImgUri
        {
            get; set;
        }

        /// <summary>
        /// ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "ID",Required = true)]
        public Guid? ID
        {
            get; set;
        }
    }
}
