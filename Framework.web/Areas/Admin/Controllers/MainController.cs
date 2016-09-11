using Framework.Dapper;
using Framework.Validate;
using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Areas.Admin.Controllers
{
    public class MainController : SuperController
    {        
        public ActionResult Index()
        {
            var user = SessionUser;
            if (user != null)
            {
                return View("Index", user.User);
            }
            else
            {
                return ExitSystem();
            }
        }

        //退出系统后台
        public RedirectResult ExitSystem()
        {
            SetSessionInfo/*清空用户信息*/(SessionInfo.USER_SESSION_NAME, null);
            SetSessionInfo/*清空用户菜单信息*/(SessionInfo.USER_MENUS, null);
            return Redirect("/Admin/Login");
        }

        //获取上传图片服务器地址
        [HttpPost]
        public void GetServerUrl()
        {
            result.Succeeded = true;
            result.Data = web.config.WebConfig.LoadElement("url");
        }
    }
}