using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_SystemUser")]
    public class EHECD_SystemUserDTO
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
        /// 登录名
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sLoginName",Required = true)]
        public String sLoginName
        {
            get; set;
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sPassWord",Required = true)]
        public String sPassWord
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
        /// 用户状态
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "tUserState",Required = true)]
        public Byte? tUserState
        {
            get; set;
        }

        /// <summary>
        /// 用户类型
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "tUserType",Required = true)]
        public Byte? tUserType
        {
            get; set;
        }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sUserNickName",Required = true)]
        public String sUserNickName
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
        /// 最后登录时间
        /// </summary>
        [FieldInfo(DataFieldLength = 8,FiledName = "dLastLoginTime",Required = true)]
        public DateTime? dLastLoginTime
        {
            get; set;
        }

        /// <summary>
        /// 所在省
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sProvice",Required = true)]
        public String sProvice
        {
            get; set;
        }

        /// <summary>
        /// 所在市
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sCity",Required = true)]
        public String sCity
        {
            get; set;
        }

        /// <summary>
        /// 所在地区
        /// </summary>
        [FieldInfo(DataFieldLength = 20,FiledName = "sCounty",Required = true)]
        public String sCounty
        {
            get; set;
        }

        /// <summary>
        /// 详细地址
        /// </summary>
        [FieldInfo(DataFieldLength = 30,FiledName = "sAddress",Required = true)]
        public String sAddress
        {
            get; set;
        }

        /// <summary>
        /// 性别
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "tSex",Required = true)]
        public Byte? tSex
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
