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
            return View("Index", user.User);
        }
        public RedirectResult ExitSystem()
        {
            SetSessionInfo(SessionInfo.USER_SESSION_NAME,null);
            SetSessionInfo(SessionInfo.USER_MENUS, null);
            return Redirect("/Admin/Login");
        }
        /// <summary>
        /// 获取上传图片服务器地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void GetServerUrl()
        {
            result.Succeeded = true;
            result.Data = web.config.WebConfig.LoadElement("url");
        }
    }
}