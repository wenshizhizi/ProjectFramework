﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;
using Framework.Domain;
using Framework.DTO;
using Framework.Validate;

namespace Framework.web.Controllers
{
    public class SuperController : Controller
    {
        //响应的对象封装对象
        protected ResponseData result = new ResponseData
        {
            Data = null,
            Succeeded = false,
            Msg = ""
        };

        //ajax请求的参数封装对象
        protected RequestData RequestParameters = new RequestData
        {
            data = null,
            identity = ""
        };

        protected UserInfo SessionUser = null;

        /// <summary>
        /// 这个地方是标识继承自该controller的菜单是否需要从session中筛选对应button
        /// </summary>
        protected Boolean NeedMenuButton = false;

        /// <summary>
        /// 处理前
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            var session = Session == null ? null : Session[SessionInfo.SESSION_NAME] as SessionInfo;
            SessionUser = session != null ? session.SessionUser : null;

            //ajax提交上来的请求
            if (requestContext.HttpContext.Request.IsAjaxRequest() && requestContext.HttpContext.Request.RequestType.ToLower() == "post")
            {
                //封装一下ajax的数据
                RequestParameters = ParameterLoader.LoadAjaxPostParameters(requestContext.HttpContext.Request.InputStream);
            }
            base.Initialize(requestContext);
        }

        /// <summary>
        /// 处理后
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();
            var requestType = filterContext.HttpContext.Request.RequestType.ToLower();

            //如果响应遇到异常
            if (filterContext.Exception != default(Exception))
            {
                //DomainInfoException表示这个是自定义的信息
                if (filterContext.Exception.GetType() == typeof(DomainInfoException))
                {
                    var ex = filterContext.Exception as DomainInfoException;
                    filterContext.ExceptionHandled = true;
                    if (ex != null && ex.IsLog)
                    {
                        SystemLog.Logs.GetLog().WriteErrorLog(ex);
                        result.Succeeded = false;
                        result.Msg = ex.Message;
                        filterContext.Result = Content(ParameterLoader.LoadResponseJSONStr(result));
                    }
                    else
                    {
                        result.Succeeded = false;
                        result.Msg = ex.Message;
                        filterContext.Result = Content(ParameterLoader.LoadResponseJSONStr(result));
                    }
                }
                else
                {
                    //处理controller的异常
                    SystemLog.Logs.GetLog().WriteErrorLog(filterContext.Exception);
                    filterContext.ExceptionHandled = true;
                    result.Succeeded = false;
                    result.Msg = filterContext.Exception.Message;
                    filterContext.Result = Content(ParameterLoader.LoadResponseJSONStr(result));
                }
            }
            else if (isAjaxRequest && requestType == "post")
            {
                //请求是脚本 ajax POST 的请求
                filterContext.Result = Content(ParameterLoader.LoadResponseJSONStr(result));

            }
            else if (isAjaxRequest && requestType == "get")
            {
                var controller = filterContext.RequestContext.RouteData.Values["controller"].ToString().ToLower();
                var action = filterContext.RequestContext.RouteData.Values["action"].ToString().ToLower();

                //排除登录和菜单、首页还有不需要按钮的标识，如果非登录和菜单、首页，
                //你需要载入按钮的话，那么把NeedMenuButton置为true就可以了
                if (controller != "login" && controller != "menu" && controller != "main" && action == "index" || NeedMenuButton)
                {
                    //请求是get请求，一般都是打开某个菜单，获取会话中的用户权限菜单信息
                    var menuinfo = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;

                    if (menuinfo != null)
                    {
                        //找到当前控制器对应的菜单信息
                        var userMenu = menuinfo.AllMenu.Where(m =>
                        {
                            return m.sUrl.Split(new char[] { '/' }).Last().ToLower() == controller;
                        }).FirstOrDefault();

                        if (userMenu != default(UserMenu))
                        {
                            //添加这个菜单有的btn,这里是会排序的，如果编辑了菜单按钮的排序，刷新就可以了
                            filterContext.Controller.ViewData.Add("btns", userMenu.Buttons.OrderBy(m=>m.iOrder).ToList());
                        }
                    }
                }
            }
            else
            {
                //其他方式的请求：暂无
            }
        }
    }
}