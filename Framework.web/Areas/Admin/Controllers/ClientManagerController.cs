using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Areas.Admin.Controllers
{
    public class ClientManagerController : SuperController
    {
        // GET: Admin/ClientManager
        public ActionResult Index()
        {
            return View();
        }
    }
}