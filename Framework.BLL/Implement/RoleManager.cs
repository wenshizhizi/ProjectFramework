using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Dapper;
using Framework.DTO;
using Framework.Helper;

namespace Framework.BLL
{
    public class RoleManager : IRoleManager
    {
        //添加角色
        public override int AddRole(dynamic data, dynamic p)
        {
            //1.创建角色对象
            EHECD_RoleDTO role = new EHECD_RoleDTO
            {
                ID = GuidHelper.GetSecuentialGuid(),
                bEnable = Convert.ToBoolean(data.bEnable.Value),
                bIsDeleted = false,
                dCreateTime = DateTime.Now,
                dModifyTime = DateTime.Now,
                iOrder = Convert.ToInt32(data.iOrder.Value),
                sRoleName = data.sRoleName.Value
            };

            var sqlIf = @"IF EXISTS(SELECT 1 FROM EHECD_Role WHERE sRoleName = @sRoleName)
                        BEGIN
	                        SELECT -1 RET;
                        END
                        ELSE
                        BEGIN
	                        {0}
                        END;";

            sqlIf = string.Format(sqlIf, DBSqlHelper.GetInsertSQL<EHECD_RoleDTO>(role));

            //2.插入角色信息
            var ret = excute.Insert(sqlIf, new { sRoleName = role.sRoleName });

            //3.记录系统日志
            InsertSystemLog(
                p.sLoginName.ToString(),
                p.sUserName.ToString(),
                p.IP.ToString(),
                (Int16)(SYSTEM_LOG_TYPE.ADD | SYSTEM_LOG_TYPE.ROLE),
                "系统用户添加角色" + role.ID,
                role.ID.ToString(),
                ret > 0);

            return ret;
        }

        //删除角色
        public override int DeleteRole(string ID, dynamic p)
        {
            StringBuilder sb = new StringBuilder();

            //1.逻辑删除这个角色的所有特权
            sb.Append(DBSqlHelper.GetUpdateSQL<EHECD_PrivilegeDTO>(new EHECD_PrivilegeDTO { bIsDeleted = true }, string.Format("WHERE ((sPrivilegeMaster = 'role' AND sPrivilegeMasterValue = '{0}'/*类别是角色*/) OR (sBelong = 'role' AND sBelongValue = '{0}'/*所有者是角色*/) OR (sPrivilegeAccess = 'role' AND sPrivilegeAccessValue = '{0}'/*提供者是角色*/))", ID)));

            //2.逻辑删除这个角色
            sb.Append(DBSqlHelper.GetUpdateSQL<EHECD_RoleDTO>(new EHECD_RoleDTO { ID = Guid.Parse(ID), bIsDeleted = true }, String.Format("WHERE ID = '{0}'", ID)));

            //3.逻辑删除这个角色绑定的客户
            sb.Append(DBSqlHelper.GetUpdateSQL<EHECD_SystemUser_R_RoleDTO>(new EHECD_SystemUser_R_RoleDTO { sRoleID = Guid.Parse(ID), bIsDeleted = true }, String.Format("WHERE sRoleID = '{0}'", ID)));

            var ret = excute.ExcuteTransaction(sb.ToString());

            //4.记录系统日志
            InsertSystemLog(
                p.sLoginName.ToString(),
                p.sUserName.ToString(),
                p.IP.ToString(),
                (Int16)(SYSTEM_LOG_TYPE.DELETE | SYSTEM_LOG_TYPE.ROLE),
                "系统用户删除角色" + ID,
                ID,
                ret > 0);

            return ret;
        }

        //编辑角色
        public override int EditRole(EHECD_RoleDTO role, dynamic p)
        {
            //1.完善角色信息
            role.dModifyTime = DateTime.Now;

            //2.更新角色信息
            var ret = excute.UpdateSingle<EHECD_RoleDTO>(role, string.Format("where ID = '{0}'", role.ID.ToString()));

            //3.记录系统日志
            InsertSystemLog(
                p.sLoginName.ToString(),
                p.sUserName.ToString(),
                p.IP.ToString(),
                (Int16)(SYSTEM_LOG_TYPE.MODIFY | SYSTEM_LOG_TYPE.ROLE),
                "系统用户编辑角色" + role.ID,
                role.ID.ToString(), ret > 0);

            return ret;
        }

        //载入角色
        public override PagingRet<EHECD_RoleDTO> LoadRoles(dynamic where)
        {
            PageInfo pageinfo = new PageInfo
            {
                OrderBy = "iOrder",
                orderType = OrderType.ASC,
                PageIndex = Convert.ToInt32(where.pageNumber.Value),
                PageSize = Convert.ToInt32(where.pageSize.Value)
            };
            return helper.PaginationQuery<EHECD_RoleDTO>("select * from EHECD_Role where bIsDeleted = 0 and sRoleName like @sRoleName", pageinfo, new { sRoleName = "%" + where.sRoleName.Value + "%" });
        }

        //载入所有角色
        public override IList<EHECD_RoleDTO> LoadAllRoles()
        {
            return helper.QueryList<EHECD_RoleDTO>("SELECT ID,sRoleName FROM EHECD_Role WHERE bIsDeleted = 0 AND bEnable = 1", null);
        }

        //载入用户权限
        public override IList<EHECD_RoleDTO> LoadUserRole(EHECD_SystemUserDTO user)
        {
            return helper.QueryList<EHECD_RoleDTO>("SELECT r.ID FROM EHECD_Role r,EHECD_SystemUser_R_Role srr WHERE r.bIsDeleted = 0 AND r.bEnable = 1 AND r.ID = srr.sRoleID AND srr.bIsDeleted = 0 AND srr.sUserID = @ID", new { ID = user.ID.ToString() });
        }

        //载入菜单
        public override dynamic LoadDistributionMenu(EHECD_RoleDTO role)
        {
            try
            {
                //1.获取所有菜单
                var allMenus = helper.QueryList<EHECD_FunctionMenuDTO>("SELECT * FROM EHECD_FunctionMenu WHERE bIsDeleted = 0;", null);

                //2.获取角色的菜单
                var roleMenus = helper.QueryList<EHECD_FunctionMenuDTO>(
                                                            @"SELECT
	                                                            sPrivilegeAccessValue ID
                                                            FROM
	                                                            EHECD_Privilege
                                                            WHERE
	                                                            sPrivilegeMaster = 'role'
                                                            AND sPrivilegeAccess = 'menu'
                                                            AND sBelong = 'role'
                                                            AND bIsDeleted = 0
                                                            AND bPrivilegeOperation = 0
                                                            AND sPrivilegeMasterValue = @ID;", new { ID = role.ID });

                var temp/*转换用户数据结构*/ = (from o in allMenus
                                        select new UserMenu
                                        {
                                            ID = o.ID,
                                            Buttons = new List<UserMenuButton>(),
                                            ChildMenu = new List<UserMenu>(),
                                            iOrder = o.iOrder,
                                            sMenuName = o.sMenuName,
                                            sPID = o.sPID,
                                            sUrl = o.sUrl
                                        }).ToList();

                //载入用户菜单层级关系
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].sPID == null)
                    {
                        temp[i].ChildMenu = LoadMenuData(temp, temp[i]);
                    }
                }

                //创建菜单数据
                var ret = temp.Where(m => m.sPID == null).Select(o => new
                {
                    id = o.ID,
                    text = o.sMenuName,
                    @checked = roleMenus.Count > 0 ? roleMenus.Where(m => m.ID == o.ID).FirstOrDefault() != default(EHECD_FunctionMenuDTO) : false,
                    children = CreateChidrenMenuTreeData(o.ChildMenu, roleMenus)
                }).ToList();
                                
                return JSONHelper.GetJsonString<dynamic>(ret);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        private List<dynamic> CreateChidrenMenuTreeData(IList<UserMenu> childMenu, IList<EHECD_FunctionMenuDTO> roleMenus)
        {
            var ret = new List<dynamic>();
            for (int i = 0; i < childMenu.Count; i++)
            {
                ret.Add(new
                {
                    id = childMenu[i].ID,
                    text = childMenu[i].sMenuName,
                    @checked = roleMenus.Count > 0 ? roleMenus.Where(m => m.ID == childMenu[i].ID).FirstOrDefault() != default(EHECD_FunctionMenuDTO) : false,
                    children = CreateChidrenMenuTreeData(childMenu[i].ChildMenu,roleMenus)
                });
            }
            return ret;
        }

        private List<UserMenu> LoadMenuData(List<UserMenu> menu, UserMenu parent)
        {
            var ret = new List<UserMenu>();
            for (int i = 0; i < menu.Count; i++)
            {
                if (parent.ID == menu[i].sPID)
                {
                    //parent.ChildMenu
                    ret.Add(menu[i]);
                    menu[i].ChildMenu = LoadMenuData(menu, menu[i]);
                }
            }
            return ret;
        }
    }
}
