using Framework.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Framework.DI.DIEntity.GetInstance().GetImpl<Framework.Dapper.ExcuteHelper>().InsertSingle<DTO.EHECD_AccountDTO>(new DTO.EHECD_AccountDTO
            {
                ID = Framework.Helper.GuidHelper.GetSecuentialGuid(),
                bIsDeleted = false,
                dCreateTime = DateTime.Now,
                iOrder = 0,
                iType = 0,
                sLoginName = "yangyukun",
                sLoginPwd = "123",
                sRealName = "yangyukun"
            });
            return Redirect("/Admin/Main");
        }
    }
}