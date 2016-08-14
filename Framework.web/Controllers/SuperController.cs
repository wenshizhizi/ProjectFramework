using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;


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
        
        /// <summary>
        /// 处理前
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.IsAjaxRequest() && requestContext.HttpContext.Request.RequestType.ToLower() == "post")
            {
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
            if (filterContext.Exception != default(Exception))
            {
                //处理controller的异常
                Log.Logs.GetLog().WriteErrorLog(filterContext.Exception);
                filterContext.ExceptionHandled = true;               
            }
            else if (filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.HttpContext.Request.RequestType.ToLower() == "post")
            {
                filterContext.Result = Content(ParameterLoader.LoadResponseJSONStr(result));
            }
        }
    }
}