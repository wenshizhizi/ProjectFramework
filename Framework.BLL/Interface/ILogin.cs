using Framework.DI;
using Framework.DTO;

namespace Framework.BLL
{
    public abstract class ILogin : BaseBll
    {
        
        /// <summary>
        /// 系统用户登录
        /// </summary>
        /// <returns>登录结果，成功返回用户，失败返回null</returns>
        public abstract EHECD_SystemUserDTO Login(EHECD_SystemUserDTO t);

        /// <summary>
        /// 载入用户权限信息
        /// </summary>
        /// <param name="t">系统用户</param>
        /// <returns>用户权限相关信息（按钮，菜单等）</returns>
        public abstract UserRoleMenuInfo LoadUserRoleMenuInfo(EHECD_SystemUserDTO t);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="t">用户信息</param>
        /// <returns>修改后的用户信息</returns>
        public virtual EHECD_SystemUserDTO ChangeUserInfo(EHECD_SystemUserDTO t)
        {
            return default(EHECD_SystemUserDTO);
        }

        /// <summary>
        /// 修改密码
        /// </summary>        
        /// <param name="t">用户信息</param>
        /// <returns>修改后的用户信息</returns>
        public virtual EHECD_SystemUserDTO ChangePassword(EHECD_SystemUserDTO t)
        {
            return default(EHECD_SystemUserDTO);
        }

        /// <summary>
        /// session使用-获取用户基本基本信息
        /// </summary>
        /// <param name="ID">用户ID</param>
        /// <returns>用户的基本信息</returns>
        public EHECD_SystemUserDTO GetAppLoginInfo(string ID)
        {
            return query.SingleQuery<EHECD_SystemUserDTO>("SELECT ID,sLoginName,sUserName,tUserState,tUserType,sUserNickName,dLastLoginTime,sProvice,sCity,sCounty,sAddress,tSex FROM EHECD_SystemUser WHERE ID=@ID AND bIsDeleted = 0", new { ID = ID });
        }
    }
}
