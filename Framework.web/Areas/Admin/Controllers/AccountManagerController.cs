using Framework.Dapper;
using Framework.Domain;
using Framework.Validate;
using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Areas.Admin.Controllers
{
    public class AccountManagerController : SuperController
    {        
        public ActionResult Index()
        {            
            return PartialView();
        }

        public void LoadAccounts()
        {
            var page = JSONHelper.GetModel<PageInfo>(RequestParameters.data.ToString());
            UserDomain user = new UserDomain();
            result.Data = user.LoadUsers(page);
            result.Succeeded = true;
        }
    }
}