using Framework.DI;
using Framework.DTO;
using Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.BLL
{
    public class UserLogin : ILogin
    {


        public override EHECD_AccountDTO Login(EHECD_AccountDTO t)
        {
            //获取查询实体
            var helper = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();

            //查询数据
            t = helper.SingleQuery<EHECD_AccountDTO>("select * from EHECD_Account where sLoginName = @name and sLoginPwd = @pwd and bIsDeleted = 0", new { name = t.sLoginName, pwd = Security.GetMD5Hash(t.sLoginPwd) });

            if (t != default(EHECD_AccountDTO))
            {
                //登录成功                
                return t;
            }
            else
            {
                return null;
            }
        }
    }
}
