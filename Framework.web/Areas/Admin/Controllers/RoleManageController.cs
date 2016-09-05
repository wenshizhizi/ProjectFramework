﻿using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Framework.DTO;
using Framework.DI;
using System.Web.Mvc;
using Framework.BLL;

namespace Framework.web.Areas.Admin.Controllers
{
    public class RoleManageController : SuperController
    {
        // GET: Admin/RoleManage
        public PartialViewResult Index()
        {
            return PartialView();
        }

        /// <summary>
        /// 载入角色列表
        /// </summary>
        public void LoadRoles()
        {
            var param = RequestParameters.data;
            var manager = DIEntity.GetInstance().GetImpl<IRoleManager>();
            var ret = manager.LoadRoles(param);
            result.Data = ret;
            result.Succeeded = true;
        }

        /// <summary>
        /// 跳转到添加角色页面
        /// </summary>
        /// <returns></returns>
        public PartialViewResult ToAddRole()
        {
            return PartialView("AddRole");
        }

        /// <summary>
        /// 跳转到编辑角色页面
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public PartialViewResult ToEditRole(EHECD_RoleDTO role)
        {
            return PartialView("EditRole", role);
        }


        public void EditRole()
        {
            var manager = DIEntity.GetInstance().GetImpl<IRoleManager>();
            var ret = manager.EditRole(JSONHelper.GetModel<EHECD_RoleDTO>(RequestParameters.dataStr));
            if (ret)
            {
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "编辑失败，请联系管理员";
            }
        }

        public void AddRole()
        {
            var manager = DIEntity.GetInstance().GetImpl<IRoleManager>();
            var ret = manager.AddRole(RequestParameters.data);
            if (ret)
            {
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "添加失败，请联系管理员";
            }
        }
    }
}