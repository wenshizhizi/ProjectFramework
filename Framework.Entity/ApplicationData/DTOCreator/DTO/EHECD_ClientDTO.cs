using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace Framework.DTO
{
    [Serializable]
    [TableInfo(TableName = "EHECD_Client")]
    public class EHECD_ClientDTO
    {

        /// <summary>
        /// ID
        /// </summary>
        [FieldInfo(DataFieldLength = 16,FiledName = "ID",Required = true)]
        public Guid? ID
        {
            get; set;
        }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [FieldInfo(DataFieldLength = 255,FiledName = "sName",Required = true)]
        public String sName
        {
            get; set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        [FieldInfo(DataFieldLength = 11,FiledName = "sPhone",Required = true)]
        public String sPhone
        {
            get; set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        [FieldInfo(DataFieldLength = 50,FiledName = "sPassWord",Required = true)]
        public String sPassWord
        {
            get; set;
        }

        /// <summary>
        /// 头像地址
        /// </summary>
        [FieldInfo(DataFieldLength = 255,FiledName = "sHeadPic",Required = true)]
        public String sHeadPic
        {
            get; set;
        }

        /// <summary>
        /// 1-正常   0-冻结
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "iState",Required = true)]
        public Int32? iState
        {
            get; set;
        }

        /// <summary>
        /// 删除标志
        /// </summary>
        [FieldInfo(DataFieldLength = 1,FiledName = "bIsDeleted",Required = true)]
        public Boolean? bIsDeleted
        {
            get; set;
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        [FieldInfo(DataFieldLength = 8,FiledName = "dAddTime",Required = true)]
        public DateTime? dAddTime
        {
            get; set;
        }

        /// <summary>
        /// 账户余额
        /// </summary>
        [FieldInfo(DataFieldLength = 9,FiledName = "dAccountBalance",Required = true)]
        {
            get; set;
        }

        /// <summary>
        /// 0-普通客户
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "iClientType",Required = true)]
        public Int32? iClientType
        {
            get; set;
        }

        /// <summary>
        /// 支付密码
        /// </summary>
        [FieldInfo(DataFieldLength = 50,FiledName = "sPayPassWord",Required = true)]
        public String sPayPassWord
        {
            get; set;
        }

        /// <summary>
        /// 支付密码安全等级 0.无  1.弱  2.中 3.强
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "sPayPassWordGrade",Required = true)]
        public Int32? sPayPassWordGrade
        {
            get; set;
        }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [FieldInfo(DataFieldLength = 50,FiledName = "sMail",Required = true)]
        public String sMail
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [FieldInfo(DataFieldLength = 0,FiledName = "sRemark",Required = true)]
        public String sRemark
        {
            get; set;
        }

        /// <summary>
        /// 注册邀请码
        /// </summary>
        [FieldInfo(DataFieldLength = 30,FiledName = "sRegCode",Required = true)]
        public String sRegCode
        {
            get; set;
        }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        [FieldInfo(DataFieldLength = 8,FiledName = "dLoginEndTime",Required = true)]
        public DateTime? dLoginEndTime
        {
            get; set;
        }

        /// <summary>
        /// 数据来源（1-PC，2-微信，3-安卓，4-IOS）
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "iSource",Required = true)]
        public Int32? iSource
        {
            get; set;
        }

        /// <summary>
        /// 昵称
        /// </summary>
        [FieldInfo(DataFieldLength = 30,FiledName = "sNickName",Required = true)]
        public String sNickName
        {
            get; set;
        }

        /// <summary>
        /// 性别:1男,2女
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "iSex",Required = true)]
        public Int32? iSex
        {
            get; set;
        }

        /// <summary>
        /// qq
        /// </summary>
        [FieldInfo(DataFieldLength = 30,FiledName = "sQQ",Required = true)]
        public String sQQ
        {
            get; set;
        }

        /// <summary>
        /// 生日
        /// </summary>
        [FieldInfo(DataFieldLength = 8,FiledName = "dBirthday",Required = true)]
        public DateTime? dBirthday
        {
            get; set;
        }

        /// <summary>
        /// 年龄
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "iAge",Required = true)]
        public Int32? iAge
        {
            get; set;
        }

        /// <summary>
        /// 学历 （文盲 小学 中学 高中  学士  硕士 博士）
        /// </summary>
        [FieldInfo(DataFieldLength = 30,FiledName = "sEduBackground",Required = true)]
        public String sEduBackground
        {
            get; set;
        }

        /// <summary>
        /// 职业
        /// </summary>
        [FieldInfo(DataFieldLength = 50,FiledName = "sPofessional",Required = true)]
        public String sPofessional
        {
            get; set;
        }

        /// <summary>
        /// 收入
        /// </summary>
        [FieldInfo(DataFieldLength = 9,FiledName = "dIncome",Required = true)]
        {
            get; set;
        }

        /// <summary>
        /// 证件类型
        /// </summary>
        [FieldInfo(DataFieldLength = 50,FiledName = "sIDType",Required = true)]
        public String sIDType
        {
            get; set;
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        [FieldInfo(DataFieldLength = 50,FiledName = "sIDCard",Required = true)]
        public String sIDCard
        {
            get; set;
        }

        /// <summary>
        /// 积分
        /// </summary>
        [FieldInfo(DataFieldLength = 4,FiledName = "iIntegral",Required = true)]
        public Int32? iIntegral
        {
            get; set;
        }
    }
}
