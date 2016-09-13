using Framework.DI;
using Framework.DTO;
using Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.BLL
{
    public class BaseBll
    {

        protected Dapper.QueryHelper helper = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();
        protected Dapper.ExcuteHelper excute = DIEntity.GetInstance().GetImpl<Dapper.ExcuteHelper>();
        protected ISystemLogManager sysLog = DIEntity.GetInstance().GetImpl<ISystemLogManager>();

        protected void InsertSystemLog(string ulname, string uname, string ip, short type, string detail, string doid, bool doret)
        {

            var log = doret ?
                new EHECD_SystemLogDTO
                {
                    bIsDeleted = false,
                    dInsertTime = DateTime.Now,
                    ID = GuidHelper.GetSecuentialGuid(),
                    sIPAddress = ip,
                    sLoginName = ulname,
                    sUserName = uname,
                    sDomainDetail = detail,
                    sDoMainId = doid,
                    tDoType = type
                } :
                new EHECD_SystemLogDTO
                {
                    bIsDeleted = false,
                    dInsertTime = DateTime.Now,
                    ID = GuidHelper.GetSecuentialGuid(),
                    sIPAddress = ip,
                    sLoginName = ulname,
                    sUserName = uname,
                    sDomainDetail = detail + "失败",
                    sDoMainId = doid,
                    tDoType = type
                };

            sysLog.InsertSystemLog(log, excute);
        }
    }
}
