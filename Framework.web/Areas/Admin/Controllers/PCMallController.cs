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
    public class PCMallController : SuperController
    {        
        public ActionResult Index()
        {            
            return View();
        }
    }
}