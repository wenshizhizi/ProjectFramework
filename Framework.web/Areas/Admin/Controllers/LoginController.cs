using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.DTO;
using Framework.Validate;
using Framework.web.Controllers;
using Framework.Domain;
using Framework.BLL;
using Framework.DI;

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
            //获取上传的账户信息
            var user = JSONHelper.GetModel<EHECD_SystemUserDTO>(RequestParameters.data.ToString());

            //获取session信息
            SessionInfo session = (SessionInfo)Session[SessionInfo.USER_SESSION_NAME];

            //校验验证码:这里偷了个懒，用的EHECD_SystemUserDTO的sUserName临时装了一下
            if (user.sUserName.ToLower() != session.ImgCode.VCodeContent.ToLower())
            {
                result.Succeeded = false;
                result.Msg = "验证码验证失败，请输入正确的验证码";
                return;
            }

            ILogin login = DIEntity.GetInstance().GetImpl<ILogin>();

            var dto = login.Login(user);

            if (dto != null)
            {
                //获取该用户的权限
                var userRoleMenu = login.LoadUserRoleMenuInfo(dto);
                if (userRoleMenu.LoadSuccess)
                {
                    session.SessionUser.User = dto;
                    Session[SessionInfo.USER_SESSION_NAME/*用户的信息*/] = session;
                    Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] = userRoleMenu;
                    result.Succeeded = true;
                    result.Data = "/Admin/Main";
                }
                else
                {
                    result.Succeeded = false;
                    result.Msg = "登录失败，权限菜单获取失败";
                }
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "登录失败，用户名或密码错误";
            }
        }
    }
}