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


        public override EHECD_SystemUserDTO Login(EHECD_SystemUserDTO t)
        {
            //获取查询实体
            var helper = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();

            //查询数据
            t = helper.SingleQuery<EHECD_SystemUserDTO>("SELECT ID,sLoginName,sUserName,tUserState,tUserType,sUserNickName,dLastLoginTime,sProvice,sCity,sCounty,sAddress,tSex FROM EHECD_SystemUser WHERE sLoginName = @name and sPassWord = @pwd AND bIsDeleted = 0;", new { name = t.sLoginName, pwd = Security.GetMD5Hash(t.sPassWord) });

            if (t != default(EHECD_SystemUserDTO))
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
