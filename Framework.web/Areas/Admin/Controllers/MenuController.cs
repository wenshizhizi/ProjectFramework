using Framework.DTO;
using Framework.Validate;
using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Areas.Admin.Controllers
{
    public class MenuController : SuperController
    {
        // GET: Admin/Menu
        public ActionResult Index()
        {
            var userRoleMenu = GetSessionInfo(SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/) as UserRoleMenuInfo;
            if (userRoleMenu != null)
            {
                return View(userRoleMenu);
            }
            else
            {
                return null;
            }
        }
    }
}