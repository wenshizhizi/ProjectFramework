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
        public override bool AddRole(dynamic data)
        {
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

            return excute.InsertSingle<EHECD_RoleDTO>(role) > 0;
        }

        public override int DeleteRole(string ID)
        {
            StringBuilder sb = new StringBuilder();

            //1.逻辑删除这个角色的所有特权
            sb.Append(DBSqlHelper.GetUpdateSQL<EHECD_PrivilegeDTO>(new EHECD_PrivilegeDTO { bIsDeleted = true }, string.Format("WHERE ((sPrivilegeMaster = 'role' AND sPrivilegeMasterValue = '{0}'/*类别是角色*/) OR (sBelong = 'role' AND sBelongValue = '{0}'/*所有者是角色*/) OR (sPrivilegeAccess = 'role' AND sPrivilegeAccessValue = '{0}'/*提供者是角色*/))", ID)));

            //2.逻辑删除这个角色
            sb.Append(DBSqlHelper.GetUpdateSQL<EHECD_RoleDTO>(new EHECD_RoleDTO { ID = Guid.Parse(ID), bIsDeleted = true },String.Format("WHERE ID = '{0}'",ID)));

            //3.逻辑删除这个角色绑定的客户
            sb.Append(DBSqlHelper.GetUpdateSQL<EHECD_SystemUser_R_RoleDTO>(new EHECD_SystemUser_R_RoleDTO { sRoleID = Guid.Parse(ID), bIsDeleted = true }, String.Format("WHERE sRoleID = '{0}'", ID)));

            return excute.ExcuteTransaction(sb.ToString());
        }

        public override bool EditRole(EHECD_RoleDTO role)
        {
            role.dModifyTime = DateTime.Now;
            return excute.UpdateSingle<EHECD_RoleDTO>(role, string.Format("where ID = '{0}'", role.ID.ToString())) > 0;
        }

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
    }
}
