using Framework.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO;

namespace Framework.BLL
{
    public abstract class IRoleManager : BaseBll
    {
        public abstract PagingRet<EHECD_RoleDTO> LoadRoles(dynamic where);
    }
}
