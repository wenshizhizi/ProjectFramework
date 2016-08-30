using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO;
using Framework.Helper;

namespace Framework.BLL
{
    public class MenuManager : IMenuManager
    {
        public override EHECD_MenuButtonDTO AddButton(EHECD_MenuButtonDTO dto, string menuID)
        {
            dto.bIsDeleted = false;
            dto.ID = Helper.GuidHelper.GetSecuentialGuid();

            EHECD_PrivilegeDTO pri = new EHECD_PrivilegeDTO
            {
                bIsDeleted = false,
                bPrivilegeOperation = false,
                ID = GuidHelper.GetSecuentialGuid(),
                sBelong = "menu",
                sBelongValue = Guid.Parse(menuID),
                sPrivilegeAccess = "button",
                sPrivilegeAccessValue = dto.ID,
                sPrivilegeMaster = "menu",
                sPrivilegeMasterValue = Guid.Parse(menuID)
            };
            var param = new List<object>();
            param.AddRange(new object[] { dto, pri });
            var ret = excute.InsertMultiple<object>(param);
            if (ret > 0)
            {
                return dto;
            }
            else
            {
                return null;
            }
        }

        public override EHECD_FunctionMenuDTO AddMenu(EHECD_FunctionMenuDTO dto)
        {
            dto.bIsDeleted = false;
            dto.ID = Helper.GuidHelper.GetSecuentialGuid();
            var ret = excute.InsertSingle<EHECD_FunctionMenuDTO>(dto);
            if (ret > 0)
            {
                return dto;
            }
            else
            {
                return null;
            }
        }

        public override EHECD_MenuButtonDTO EditButton(EHECD_MenuButtonDTO dto)
        {
            dto.bIsDeleted = false;
            var ret = excute.UpdateSingle<EHECD_MenuButtonDTO>(dto,string.Format("WHERE [ID] = '{0}'", dto.ID));
            if (ret > 0)
            {
                return dto;
            }
            else
            {
                return null;
            }
        }
    }
}
