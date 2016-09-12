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
    public class SystemUserManager : ISystemUserManager
    {
        public override int AddSystemUser(EHECD_SystemUserDTO user,dynamic p)
        {
            user.bIsDeleted = false;
            user.dCreateTime = DateTime.Now;
            user.dLastLoginTime = DateTime.Now;
            user.tUserState = 0;
            user.tUserType = 0;
            user.ID = Helper.GuidHelper.GetSecuentialGuid();
            user.sPassWord = Helper.Security.GetMD5Hash(user.sPassWord);

            var ret = excute.InsertSingle<EHECD_SystemUserDTO>(user);

            if (ret > 0)
            {
                var log = new EHECD_SystemLogDTO
                {
                    bIsDeleted = false,
                    dInsertTime = DateTime.Now,
                    ID = GuidHelper.GetSecuentialGuid(),
                    sIPAddress = p.IP.ToString(),
                    sLoginName = p.sLoginName.ToString(),
                    sUserName = p.sUserName.ToString(),
                    sDomainDetail = "系统用户添加用户" + user.ID
                };
                sysLog.InsertSystemLog(log, excute);
            }
            else
            {
                var log = new EHECD_SystemLogDTO
                {
                    bIsDeleted = false,
                    dInsertTime = DateTime.Now,
                    ID = GuidHelper.GetSecuentialGuid(),
                    sIPAddress = p.IP.ToString(),
                    sLoginName = p.sLoginName.ToString(),
                    sUserName = p.sUserName.ToString(),
                    sDomainDetail = "系统用户添加用户" + user.ID + "失败"
                };
                sysLog.InsertSystemLog(log, excute);
            }

            return ret;
        }

        public override PagingRet<EHECD_SystemUserDTO> LoadSystemUsers(PageInfo page, dynamic where)
        {
            return helper.PaginationQuery<EHECD_SystemUserDTO>("SELECT ID,sLoginName,sUserName,tUserState,tUserType,sUserNickName,dCreateTime,dLastLoginTime,sMobileNum FROM EHECD_SystemUser WHERE sLoginName LIKE @sLoginName", page, new { sLoginName = "%" + where.sLoginName.Value.ToString() + "%" });
        }
    }
}
