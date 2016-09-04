using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Framework.DTO;
using Framework.DI;
using System.Web.Mvc;
using Framework.BLL;

namespace Framework.web.Areas.Admin.Controllers
{
    public class RoleManageController : SuperController
    {
        // GET: Admin/RoleManage
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public void LoadRoles()
        {
            var param = RequestParameters.data;
            var manager = DIEntity.GetInstance().GetImpl<IRoleManager>();
            var ret = manager.LoadRoles(param);
            result.Data = ret;
            result.Succeeded = true;
        }
    }
}