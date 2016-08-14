using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.DTO;
using Framework.Validate;
using Framework.web.Controllers;
using Framework.Domain;

namespace Framework.web.Areas.Admin.Controllers
{
    public class LoginController : SuperController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public void Login()
        {
            var user = JSONHelper.GetModel<Account>(RequestParameters.data.ToString());

            SessionInfo session = (SessionInfo)Session[SessionInfo.SESSION_NAME];

            if (user.sRealName.ToLower() != session.ImgCode.VCodeContent.ToLower())
            {
                result.Succeeded = false;
                result.Msg = "验证码验证失败，请输入正确的验证码";
            }

            UserDomain udo = new UserDomain();
            udo.user = user;

            var dto = udo.Login();

            if (dto!=null)
            {
                session.SessionUser.User = dto;
                Session[SessionInfo.SESSION_NAME] = session;                
                result.Succeeded = true;
                result.Data = "/Admin/Main";
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "登录失败，用户名或密码错误";
            }
        }
    }
}