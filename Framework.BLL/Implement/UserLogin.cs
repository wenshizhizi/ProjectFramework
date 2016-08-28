using Framework.DI;
using Framework.DTO;
using Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.web.config;

namespace Framework.BLL
{
    public class UserLogin : ILogin
    {
        public override UserRoleMenuInfo LoadUserRoleMenuInfo(EHECD_SystemUserDTO t)
        {
            //用户的权限和菜单、菜单按钮信息
            UserRoleMenuInfo ret = new UserRoleMenuInfo();

            //从配置中查看启不启用权限
            if (WebConfig.LoadElement("UseUserRole") == "1")
            {
                //获取用户的权限
                ret.UserRole = helper.QueryList<UserRole>(@"SELECT
	                                                            r.ID,
	                                                            r.sRoleName,
	                                                            r.dModifyTime,
	                                                            r.iOrder
                                                            FROM
	                                                            EHECD_SystemUser_R_Role srr,
	                                                            EHECD_Role r
                                                            WHERE
	                                                            srr.sRoleID = r.ID
                                                            AND r.bIsDeleted = 0
                                                            AND srr.bIsDeleted = 0
                                                            AND r.bEnable = 0
                                                            AND srr.sUserID = @id ORDER BY r.iOrder;", new { id = t.ID });

                //获取用户和用户角色下的菜单
                ret.UserMenu = helper.QueryList<UserMenu>(@"SELECT * FROM EHECD_FunctionMenu WHERE ID IN(
                                                            SELECT
	                                                            a.sPrivilegeAccessValue
                                                            FROM
	                                                            EHECD_Privilege a
                                                            WHERE
	                                                            a.sPrivilegeMaster = 'role' /*指定特权是分发给角色的*/
                                                            AND a.sPrivilegeAccess = 'menu'/*指定分发给角色的特权是菜单*/
                                                            AND a.sPrivilegeMasterValue IN (
	                                                            SELECT
		                                                            sRoleID
	                                                            FROM
		                                                            EHECD_SystemUser_R_Role
	                                                            WHERE
		                                                            sUserID = @ID
	                                                            AND bIsDeleted = 0
                                                            )/*根据用户ID获取到他的角色以指定他的角色所拥有的特权*/
                                                            AND a.bIsDeleted = 0
                                                            AND a.sPrivilegeOperation = 0
                                                            UNION
	                                                            SELECT
		                                                            a.sPrivilegeAccessValue
	                                                            FROM
		                                                            EHECD_Privilege a
	                                                            WHERE
		                                                            a.sPrivilegeMaster = 'user' /*指定特权是分发给客户的*/	
	                                                            AND a.sPrivilegeAccess = 'menu'/*指定分发给客户的特权是菜单*/
	                                                            AND a.sPrivilegeMasterValue = @ID/*指定要查的用户拥有的特权*/
	                                                            AND a.bIsDeleted = 0
	                                                            AND a.sPrivilegeOperation = 0
                                                            );", new { ID = t.ID });

                //判断是否开启菜单按钮
                if (WebConfig.LoadElement("UseMenuBottn") == "1")
                {
                    //获取用户的菜单按钮
                    Parallel.For(0, ret.UserMenu.Count, index => {
                        ret.UserMenu[index].Buttons = helper.QueryList<UserMenuButton>("", new { ID = ret.UserMenu[index].ID });
                    });
                }                
            }
            else
            {
                //如果不启用权限，就获取所有菜单
                ret.UserMenu = helper.QueryList<UserMenu>("SELECT ID,sMenuName,sPID,sUrl,iOrder from EHECD_FunctionMenu WHERE bIsDeleted = 0 ORDER BY iOrder;", null);

                var userMs = new List<UserMenu>();

                //初始化菜单层级关系
                foreach (var item in ret.UserMenu)
                {
                    //顶层菜单
                    if (item.sPID == null)
                    {
                        LoadLevelUserMenu(ret.UserMenu, item);
                        userMs.Add(item);
                    }
                }
                ret.UserMenu = userMs;

                //判断是否开启菜单按钮
                if (WebConfig.LoadElement("UseMenuBottn") == "1")
                {
                    //获取用户菜单按钮
                }                

                ret.LoadSuccess = true;            
            }
            
            return ret;
        }

        /// <summary>
        /// 递归从集合中载入指定菜单的下级菜单，直到没有下级菜单
        /// </summary>
        /// <param name="t"></param>
        /// <param name="m"></param>
        private void LoadLevelUserMenu(IList<UserMenu> t, UserMenu m)
        {
            Parallel.For(0, t.Count, index =>
            {
                var temp = t[index];
                if (m.ID == temp.sPID)
                {
                    m.ChildMenu.Add(temp);
                    LoadLevelUserMenu(t, temp);
                }
            });
        }

        public override EHECD_SystemUserDTO Login(EHECD_SystemUserDTO t)
        {
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
