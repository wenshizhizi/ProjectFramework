using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DI;
using Framework.DTO;
using Framework.MapperConfig;
using Framework.Helper;
using Framework.Dapper;

namespace Framework.Domain
{
    /// <summary>
    /// 用户领域
    /// </summary>
    public class UserDomain
    {
        public Account user = new Account();

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public EHECD_AccountDTO Login()
        {
            //获取查询实体
            var helper = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();
            //映射数据对象
            var dto = MapperHelpper.Map<EHECD_AccountDTO>(user);
            //查询数据
            dto = helper.SingleQuery<EHECD_AccountDTO>(
                "select * from EHECD_Account where sLoginName = @name and sLoginPwd = @pwd and bIsDeleted = 0",
                new { name = dto.sLoginName, pwd = Security.GetMD5Hash(dto.sLoginPwd) });

            if (dto != default(EHECD_AccountDTO))
            {
                //登录成功                
                return dto;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改用户的账户信息
        /// </summary>
        /// <returns></returns>
        public bool ChangeAccountInfo()
        {
            return false;
        }

        public PagingRet<Dictionary<string,object>> LoadUsers(PageInfo page)
        {
            //获取查询实体
            var helper = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();

            return helper.PaginationQuery<Dictionary<string, object>>("select sRealName,sLoginName,case when iType = 0 then '公司员工' else '管理员' end iType from EHECD_Account", page, null);
        }
    }
}
