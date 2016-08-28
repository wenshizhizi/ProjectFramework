using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO;

namespace Framework.BLL
{
    public class MenuManager : IMenuManager
    {
        public override Guid? AddMenu(EHECD_FunctionMenuDTO dto)
        {
            dto.bIsDeleted = false;
            dto.ID = Helper.GuidHelper.GetSecuentialGuid();
            var ret = excute.InsertSingle<EHECD_FunctionMenuDTO>(dto);
            if(ret > 0)
            {
                return dto.ID;
            }
            else
            {
                return null;
            }
        }
    }
}
