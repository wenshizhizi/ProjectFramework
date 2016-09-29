using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Framework.DTO;
using Framework.Validate;
using Framework.web.Controllers;
using Framework.AppCache;
using Framework.BLL;
using Framework.DI;
using Framework.Helper;

namespace Framework.web.Areas.Admin.Controllers
{
    public class LoginController : SuperController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 发送重置密码的短信验证码
        /// </summary>
        public void SendMessage()
        {
            var param = LoadParam<Dictionary<string, string>>()["sloginName"];

            if (ApplicationCache.Instance.GetValue(param) != null)
            {
                result.Succeeded = false;
                result.Msg = "两分钟内已经获取过验证短信，请等待两分后再获取";
                return;
            }
                        
            var login = base.LoadInterface<ILogin>();
            var mnumber = login.QueryMobileNumberByLoginName(param);
            if (mnumber != null)
            {
                var messger = base.LoadInterface<IMessager>();
                var code = RandomHelper.GetRandomIntString();
                if (messger.SendMessage(mnumber, string.Format(messger.ChangePWDMessage, code)))
                {
                    ApplicationCache.Instance.SetValue(param, code, 120);
                    result.Succeeded = true;
                }
                else
                {
                    result.Succeeded = false;
                    result.Msg = "发送短消息至手机失败，请联系管理员";
                }
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "没有获取到该登录名的联系电话，请确认登录名是否正确？";
            }
        }

        public PartialViewResult ToForgetPWD()
        {

            return PartialView("ForgetPWD");
        }

        public void Login()
        {
            //获取上传的账户信息
            var user = LoadParam<EHECD_SystemUserDTO>();

            //获取session信息
            SessionInfo session = GetSessionInfo(SessionInfo.USER_SESSION_NAME) as SessionInfo;

            //校验验证码:这里偷了个懒，用的EHECD_SystemUserDTO的sUserName临时装了一下
            if (user.sUserName.ToLower() != session.ImgCode.VCodeContent.ToLower())
            {
                result.Succeeded = false;
                result.Msg = "验证码验证失败，请输入正确的验证码";
                return;
            }

            ILogin login = DIEntity.GetInstance().GetImpl<ILogin>();
            user.sAddress = RequestParameters.dynamicData.IP.Value.ToString();
            var dto = login.Login(user);

            if (dto != null)
            {
                if (dto.tUserState == 1)
                {
                    result.Succeeded = false;
                    result.Msg = "登录失败，该用户已被冻结";
                    return;
                }

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