﻿using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Areas.Admin.Controllers
{
    public class GoodsCategoryController : SuperController
    {
        // GET: Admin/GoodsCategory
        public ActionResult Index()
        {
            return View();
        }
    }
}