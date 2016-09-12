using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Dapper;
using Framework.DTO;

namespace Framework.BLL
{
    public class SystemLogManager : ISystemLogManager
    {
        public override int InsertSystemLog(EHECD_SystemLogDTO loginfo, ExcuteHelper excute)
        {
            return excute.InsertSingle<EHECD_SystemLogDTO>(loginfo);
        }
    }
}
