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
            return helper.QueryList<EHECD_RoleDTO>("SELECT ID,sRoleName FROM EHECD_Role WHERE bIsDeleted = 0 AND bEnable = 1",null);
        }
    }
}
