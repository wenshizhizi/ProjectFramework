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
        public override int AddSystemUser(EHECD_SystemUserDTO user)
        {
            user.bIsDeleted = false;
            user.dCreateTime = DateTime.Now;
            user.dLastLoginTime = DateTime.Now;
            user.tUserState = 0;
            user.tUserType = 0;
            user.ID = Helper.GuidHelper.GetSecuentialGuid();
            user.sPassWord = Helper.Security.GetMD5Hash(user.sPassWord);
            return excute.InsertSingle<EHECD_SystemUserDTO>(user);
        }

        public override PagingRet<EHECD_SystemUserDTO> LoadSystemUsers(PageInfo page, dynamic where)
        {
            return helper.PaginationQuery<EHECD_SystemUserDTO>("SELECT ID,sLoginName,sUserName,tUserState,tUserType,sUserNickName,dCreateTime,dLastLoginTime FROM EHECD_SystemUser WHERE sLoginName LIKE @sLoginName", page, new { sLoginName = "%" + where.sLoginName.Value.ToString() + "%" });
        }
    }
}
