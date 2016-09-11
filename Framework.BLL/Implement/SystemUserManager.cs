using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Dapper;
using Framework.DTO;

namespace Framework.BLL
{
    public class SystemUserManager : ISystemUserManager
    {
        public override PagingRet<EHECD_SystemUserDTO> LoadSystemUsers(PageInfo page, dynamic where)
        {
            return helper.PaginationQuery<EHECD_SystemUserDTO>("SELECT ID,sLoginName,sUserName,tUserState,tUserType,sUserNickName,dCreateTime,dLastLoginTime FROM EHECD_SystemUser WHERE sLoginName LIKE @sLoginName", page, new { sLoginName = "%" + where.sLoginName.Value.ToString() + "%" });
        }
    }
}
