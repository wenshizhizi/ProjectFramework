using Framework.BLL;
using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Areas.Admin.Controllers
{
    public class SystemUserController : SuperController
    {
        // GET: Admin/SystemUser
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 载入系统用户
        /// </summary>
        public void LoadSystemUser()
        {
            var pageinfo = JSONHelper.GetModel<Dapper.PageInfo>(RequestParameters.dataStr);
            var systemUserManager = DI.DIEntity.GetInstance().GetImpl<ISystemUserManager>();
            result.Data = systemUserManager.LoadSystemUsers(pageinfo, RequestParameters.dynamicData);
            result.Succeeded = true;
        }

        /// <summary>
        /// 跳转到添加系统用户
        /// </summary>
        /// <returns>部分试图</returns>
        public PartialViewResult ToAddSystemUser()
        {
            return PartialView("AddSystemUser");
        }
    }
}