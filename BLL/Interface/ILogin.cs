using Framework.DI;
using Framework.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.BLL
{
    public abstract class ILogin
    {
        /// <summary>
        /// 后台用户登录
        /// </summary>
        /// <returns></returns>
        public abstract EHECD_AccountDTO Login(EHECD_AccountDTO t);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual EHECD_AccountDTO ChangeUserInfo(EHECD_AccountDTO t) {
            return default(EHECD_AccountDTO);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual EHECD_AccountDTO ChangePassword(EHECD_AccountDTO t) {
            return default(EHECD_AccountDTO);
        }

        public EHECD_AccountDTO GetAppLoginInfo(string ID)
        {
            var query = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();
            return query.SingleQuery<EHECD_AccountDTO>("SELECT ID,iState,iType,sLoginName,sRealName FROM EHECD_Account WHERE ID=@ID AND bIsDeleted = 0", new { ID = ID });
        }
    }
}
