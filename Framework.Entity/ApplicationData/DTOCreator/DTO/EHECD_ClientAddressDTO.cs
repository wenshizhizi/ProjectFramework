using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_ClientAddress")]
    public class EHECD_ClientAddressDTO
    {

        /// <summary>
        /// 
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "ID",Required = true)]
        public Guid? ID
        {
            get; set;
        }

        /// <summary>
        /// 客户ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "sClientID",Required = true)]
        public Guid? sClientID
        {
            get; set;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        [FieldInfo(DataFieldLength = 100,FiledName = "sUserName",Required = true)]
        public String sUserName
        {
            get; set;
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        [FieldInfo(DataFieldLength = 30,FiledName = "sPhone",Required = true)]
        public String sPhone
        {
            get; set;
        }

        /// <summary>
        /// 省
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sProvince",Required = true)]
        public String sProvince
        {
            get; set;
        }

        /// <summary>
        /// 市
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sCity",Required = true)]
        public String sCity
        {
            get; set;
        }

        /// <summary>
        /// 区县
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sCounty",Required = true)]
        public String sCounty
        {
            get; set;
        }

        /// <summary>
        /// 具体地址
        /// </summary>
        [FieldInfo(DataFieldLength = 150,FiledName = "sAddress",Required = true)]
        public String sAddress
        {
            get; set;
        }

        /// <summary>
        /// 是否三环内
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "bIsInThreeRound",Required = true)]
        public Boolean? bIsInThreeRound
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "bIsDeleted",Required = true)]
        public Boolean? bIsDeleted
        {
            get; set;
        }

        /// <summary>
        /// 是否是默认地址
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "bIsDefault",Required = true)]
        public Boolean? bIsDefault
        {
            get; set;
        }

        /// <summary>
        /// 是否送达乡镇
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "bIsToVillage",Required = true)]
        public Boolean? bIsToVillage
        {
            get; set;
        }

        /// <summary>
        /// 维度
        /// </summary>
        [FieldInfo(DataFieldLength = 5,FiledName = "dLatitude",Required = true)]
        {
            get; set;
        }

        /// <summary>
        /// 经度
        /// </summary>
        [FieldInfo(DataFieldLength = 5,FiledName = "dLongtidude",Required = true)]
        {
            get; set;
        }
    }
}
