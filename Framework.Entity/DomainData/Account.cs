using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DTO
{
    public class Account
    {
        /// <summary>
        /// 主键
        /// </summary>		
        public Guid? ID
        {
            get; set;
        }
        /// <summary>
        /// 真实姓名
        /// </summary>		
        public string sRealName
        {
            get; set;
        }
        /// <summary>
        /// 登录名
        /// </summary>		
        public string sLoginName
        {
            get; set;
        }
        /// <summary>
        /// 密码
        /// </summary>		
        public string sLoginPwd
        {
            get; set;
        }
        /// <summary>
        /// 类型（0-公司员工 1-管理员）
        /// </summary>		
        public int? iType
        {
            get; set;
        }        
    }
}
