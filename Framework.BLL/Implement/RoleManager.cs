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
