using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;


namespace Framework.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //初始化对象映射配置
            MapperConfig.MapConfiguration.Configure();
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{
        
        //}

        /// <summary>
        /// WebApiSession启动
        /// </summary>
        //public override void Init()
        //{
        //    this.PostAuthenticateRequest += (sender, e) => HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        //    base.Init();
        //}
    }
}
