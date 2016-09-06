﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO;
using Framework.Helper;

namespace Framework.BLL
{
    public class MenuManager : IMenuManager
    {
        public override EHECD_MenuButtonDTO AddButton(EHECD_MenuButtonDTO dto, string menuID)
        {
            dto.bIsDeleted = false;
            dto.ID = Helper.GuidHelper.GetSecuentialGuid();

            EHECD_PrivilegeDTO pri = new EHECD_PrivilegeDTO
            {
                bIsDeleted = false,
                bPrivilegeOperation = false,
                ID = GuidHelper.GetSecuentialGuid(),
                sBelong = "menu",
                sBelongValue = Guid.Parse(menuID),
                sPrivilegeAccess = "button",
                sPrivilegeAccessValue = dto.ID,
                sPrivilegeMaster = "menu",
                sPrivilegeMasterValue = Guid.Parse(menuID)
            };
            var param = new List<object>();
            param.AddRange(new object[] { dto, pri });
            var ret = excute.InsertMultiple<object>(param);
            if (ret > 0)
            {
                return dto;
            }
            else
            {
                return null;
            }
        }

        public override EHECD_FunctionMenuDTO AddMenu(EHECD_FunctionMenuDTO dto)
        {
            dto.bIsDeleted = false;
            dto.ID = Helper.GuidHelper.GetSecuentialGuid();
            var ret = excute.InsertSingle<EHECD_FunctionMenuDTO>(dto);
            if (ret > 0)
            {
                return dto;
            }
            else
            {
                return null;
            }
        }

        public override int DeleteMenu(EHECD_FunctionMenuDTO menu)
        {
            StringBuilder sb = new StringBuilder();

            //1.查询当前菜单的层级关系（它和它的所有下级菜单的ID）            
            string withCTE = string.Format(@"WITH CTE (ID, sPID) AS (
	                                                                    SELECT
		                                                                    ID,
		                                                                    sPID
	                                                                    FROM
		                                                                    EHECD_FunctionMenu
	                                                                    WHERE
		                                                                    ID = @ID
	                                                                    AND	bIsDeleted = 0
	                                                                    UNION ALL
		                                                                    SELECT
			                                                                    B.ID,
			                                                                    B.sPID
		                                                                    FROM
			                                                                    CTE,
			                                                                    EHECD_FunctionMenu B
		                                                                    WHERE
			                                                                    CTE.ID = B.sPID
		                                                                    AND B.bIsDeleted = 0
                                                                    ) SELECT
	                                                                    CTE.ID
                                                                    FROM
	                                                                    CTE;", menu.ID);

            var ids = helper.QueryList<Dictionary<string, object>>(withCTE, new { ID = menu.ID.ToString() }).Select(m => m["ID"].ToString()).ToList();

            foreach (var item in ids)
            {
                //2.删除菜单数据
                //sb.Append(Dapper.DBSqlHelper.GetDeleteSQL<EHECD_FunctionMenuDTO>(menu, string.Format("where ID = '{0}'", item)));
                sb.Append(Dapper.DBSqlHelper.GetUpdateSQL<EHECD_FunctionMenuDTO>(new EHECD_FunctionMenuDTO { bIsDeleted = true }, string.Format("where ID = '{0}'", item)));

                //3.找到菜单的按钮信息
                var menus = helper.QueryList<EHECD_MenuButtonDTO>(@"WITH CTE AS (
	                                                                            SELECT
		                                                                            sPrivilegeAccessValue
	                                                                            FROM
		                                                                            [EHECD_Privilege]
	                                                                            WHERE
		                                                                            sPrivilegeMaster = 'menu'
	                                                                            AND sPrivilegeAccess = 'button'
	                                                                            AND sBelong = 'menu'
	                                                                            AND sBelongValue = @ID
                                                                            ) SELECT
	                                                                            EHECD_MenuButton.ID
                                                                            FROM
	                                                                            EHECD_MenuButton,
	                                                                            CTE
                                                                            WHERE
	                                                                            ID = CTE.sPrivilegeAccessValue;", new { ID = item });

                foreach (var button in menus)
                {
                    //4.删除对应的菜单按钮
                    //sb.Append(Dapper.DBSqlHelper.GetDeleteSQL<EHECD_MenuButtonDTO>(button, string.Format("where ID = '{0}'", button.ID.ToString())));
                    sb.Append(Dapper.DBSqlHelper.GetUpdateSQL<EHECD_MenuButtonDTO>(new EHECD_MenuButtonDTO { bIsDeleted = true }, string.Format("where ID = '{0}'", button.ID.ToString())));

                    //5.删除对应这个按钮在特权表中分发给其他所有者的特权信息（如分发给角色和指定用户的按钮特权）
                    //sb.Append(Dapper.DBSqlHelper.GetDeleteSQL<EHECD_PrivilegeDTO>(new EHECD_PrivilegeDTO(), string.Format("where ((sPrivilegeMaster = 'role' AND sBelong = 'role'/*分发给角色的*/) or (sPrivilegeMaster = 'user' AND sBelong = 'user'/*分发给用户的*/)) AND sPrivilegeAccess = 'button' and sPrivilegeAccessValue = '{0}'", button.ID.ToString())));
                    sb.Append(Dapper.DBSqlHelper.GetUpdateSQL<EHECD_PrivilegeDTO>(new EHECD_PrivilegeDTO { bIsDeleted = true }, string.Format("where ((sPrivilegeMaster = 'role' AND sBelong = 'role'/*分发给角色的*/) or (sPrivilegeMaster = 'user' AND sBelong = 'user'/*分发给用户的*/)) AND sPrivilegeAccess = 'button' and sPrivilegeAccessValue = '{0}'", button.ID.ToString())));
                }

                //6.解除菜单对应的特权信息
                //sb.Append(Dapper.DBSqlHelper.GetDeleteSQL<EHECD_PrivilegeDTO>(new EHECD_PrivilegeDTO(), string.Format("where ((sPrivilegeMaster = 'menu' AND sPrivilegeMasterValue = '{0}') or (sPrivilegeAccess = 'menu' and sPrivilegeAccessValue = '{0}') or (sBelong = 'menu' and sBelongValue = '{0}'))", item)));
                sb.Append(Dapper.DBSqlHelper.GetUpdateSQL<EHECD_PrivilegeDTO>(new EHECD_PrivilegeDTO { bIsDeleted = true }, string.Format("where ((sPrivilegeMaster = 'menu' AND sPrivilegeMasterValue = '{0}') or (sPrivilegeAccess = 'menu' and sPrivilegeAccessValue = '{0}') or (sBelong = 'menu' and sBelongValue = '{0}'))", item)));
            }

            //执行删除
            return excute.ExcuteTransaction(sb.ToString());
        }

        public override EHECD_MenuButtonDTO EditButton(EHECD_MenuButtonDTO dto)
        {
            dto.bIsDeleted = false;
            var ret = excute.UpdateSingle<EHECD_MenuButtonDTO>(dto, string.Format("WHERE [ID] = '{0}'", dto.ID));
            if (ret > 0)
            {
                return dto;
            }
            else
            {
                return null;
            }
        }

        public override EHECD_FunctionMenuDTO EditMenu(EHECD_FunctionMenuDTO menu)
        {
            var ret = excute.UpdateSingle<EHECD_FunctionMenuDTO>(menu, string.Format("WHERE [ID] = '{0}'", menu.ID));
            if (ret > 0)
            {
                return menu;
            }
            else
            {
                return null;
            }
        }
    }
}
