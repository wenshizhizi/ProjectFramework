using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Dapper;
using Framework.DTO;

namespace Framework.BLL
{
    public class RoleManager : IRoleManager
    {
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
