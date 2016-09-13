using Framework.BLL;
using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Areas.Admin.Controllers
{
    public class SystemUserController : SuperController
    {
        // GET: Admin/SystemUser
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 编辑系统用户
        /// </summary>
        public void EditSystemUser()
        {
            var user = JSONHelper.GetModel<DTO.EHECD_SystemUserDTO>(RequestParameters.dataStr);
            CreateSyslogInfo();
            var ret = DI.DIEntity
                                .GetInstance()
                                .GetImpl<ISystemUserManager>()
                                .EditSystemUser(user, RequestParameters.dynamicData);
            result.Succeeded = ret > 0;
            result.Msg = !result.Succeeded ? ret == -1 ? "编辑用户失败，已有相同登录名用户" : "编辑用户失败，请联系系统管理员" : "";
        }

        /// <summary>
        /// 删除系统用户
        /// </summary>
        public void DeleteSystemUser()
        {
            var user = JSONHelper.GetModel<DTO.EHECD_SystemUserDTO>(RequestParameters.dataStr);
            CreateSyslogInfo();
            var ret = DI.DIEntity
                                .GetInstance()
                                .GetImpl<ISystemUserManager>()
                                .DeleteSystemUser(user, RequestParameters.dynamicData);
            result.Succeeded = ret > 0;
            result.Msg = !result.Succeeded ? "删除用户失败，请联系系统管理员" : "";
        }

        /// <summary>
        /// 冻结用户
        /// </summary>
        public void FrozenSystemUser()
        {
            var user = JSONHelper.GetModel<DTO.EHECD_SystemUserDTO>(RequestParameters.dataStr);
            CreateSyslogInfo();
            var ret = DI.DIEntity
                                .GetInstance()
                                .GetImpl<ISystemUserManager>()
                                .FrozenSystemUser(user, RequestParameters.dynamicData);
            result.Succeeded = ret > 0;
            result.Msg = !result.Succeeded ? "冻结用户失败，请联系系统管理员" : "";
        }

        /// <summary>
        /// 添加系统用户
        /// </summary>
        public void AddSystemUser()
        {
            var user = JSONHelper.GetModel<DTO.EHECD_SystemUserDTO>(RequestParameters.dataStr);
            CreateSyslogInfo();
            var ret = DI.DIEntity
                                .GetInstance()
                                .GetImpl<ISystemUserManager>()
                                .AddSystemUser(user, RequestParameters.dynamicData);
            result.Succeeded = ret > 0;
            result.Msg = !result.Succeeded ? ret == -1 ? "添加用户失败，已有相同登录名用户" : "添加用户失败，请联系系统管理员" : "";
        }

        /// <summary>
        /// 载入系统用户
        /// </summary>
        public void LoadSystemUser()
        {
            var pageinfo = JSONHelper.GetModel<Dapper.PageInfo>(RequestParameters.dataStr);
            var systemUserManager = DI.DIEntity.GetInstance().GetImpl<ISystemUserManager>();
            result.Data = systemUserManager.LoadSystemUsers(pageinfo, RequestParameters.dynamicData);
            result.Succeeded = true;
        }

        /// <summary>
        /// 跳转到添加系统用户
        /// </summary>
        /// <returns>部分视图</returns>
        public PartialViewResult ToAddSystemUser()
        {
            return PartialView("AddSystemUser");
        }

        /// <summary>
        /// 跳转到编辑系统用户
        /// </summary>
        /// <returns>部分视图</returns>
        public PartialViewResult ToEditSystemUser(DTO.EHECD_SystemUserDTO user)
        {
            user = DI.DIEntity
                       .GetInstance()
                       .GetImpl<BLL.ISystemUserManager>()
                       .GetSystemUserInfoById(user);
            return PartialView("EditSystemUser", user);
        }
    }
}