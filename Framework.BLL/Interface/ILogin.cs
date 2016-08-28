using Framework.DI;
using Framework.DTO;

namespace Framework.BLL
{
    public abstract class ILogin
    {
        protected Dapper.QueryHelper helper = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();

        /// <summary>
        /// 后台用户登录
        /// </summary>
        /// <returns></returns>
        public abstract EHECD_SystemUserDTO Login(EHECD_SystemUserDTO t);

        /// <summary>
        /// 载入用户权限信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public abstract UserRoleMenuInfo LoadUserRoleMenuInfo(EHECD_SystemUserDTO t);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual EHECD_SystemUserDTO ChangeUserInfo(EHECD_SystemUserDTO t) {
            return default(EHECD_SystemUserDTO);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual EHECD_SystemUserDTO ChangePassword(EHECD_SystemUserDTO t) {
            return default(EHECD_SystemUserDTO);
        }

        /// <summary>
        /// session使用获取用户基本基本信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public EHECD_SystemUserDTO GetAppLoginInfo(string ID)
        {
            var query = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();
            return query.SingleQuery<EHECD_SystemUserDTO>("SELECT ID,sLoginName,sUserName,tUserState,tUserType,sUserNickName,dLastLoginTime,sProvice,sCity,sCounty,sAddress,tSex FROM EHECD_SystemUser WHERE ID=@ID AND bIsDeleted = 0", new { ID = ID });
        }
    }
}
