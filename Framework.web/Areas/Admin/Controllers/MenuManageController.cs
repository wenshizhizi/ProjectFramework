using Framework.BLL;
using Framework.DTO;
using Framework.Validate;
using Framework.web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Framework.web.Areas.Admin.Controllers
{
    public class MenuManageController : SuperController
    {
        // GET: Admin/MenuManage
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 载入菜单
        /// </summary>
        public void LoadAllMenu()
        {
            var userRoleMenu = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;
            result.Succeeded = userRoleMenu != null ? true : false;

            //开始组装菜单的数据
            result.Data = CreateMenuData(userRoleMenu.AllMenu);
        }

        /// <summary>
        /// 获取添加菜单的页面
        /// </summary>
        public ActionResult ToAddMenu()
        {
            return View("AddMenu");
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        public void AddMenu()
        {
            //传入的菜单参数
            EHECD_FunctionMenuDTO menu = JSONHelper.GetModel<EHECD_FunctionMenuDTO>(RequestParameters.data.ToString());

            //菜单业务对象
            IMenuManager menubll = DI.DIEntity.GetInstance().GetImpl<IMenuManager>();

            //添加菜单
            result.Data = menubll.AddMenu(menu);
            if (result.Data != null)
            {
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "添加菜单失败，请联系管理员";
            }
        }

        //创建菜单数据
        private dynamic CreateMenuData(IList<UserMenu> t)
        {
            var userMs = new List<object>();

            //初始化菜单层级关系
            foreach (var item in t)
            {
                var child = LoadLevelUserMenu(t, item);
                child.AddRange(CreateButtons(item.Buttons));
                //顶层菜单
                if (item.sPID == null)
                {
                    userMs.Add(new
                    {
                        id = item.ID,
                        text = item.sMenuName,
                        attributes = new { type = "menu" },
                        @checked = true,
                        state = "open",
                        children = child
                    });
                }
            }
            return new
            {
                id = "0",
                text = "根目录",
                attributes = new { type = "root" },
                @checked = true,
                state = "open",
                children = userMs
            };
        }

        //载入带层级的菜单
        private List<object> LoadLevelUserMenu(IList<UserMenu> t, UserMenu m)
        {
            var userMs = new List<object>();
            for (int i = 0; i < t.Count; i++)
            {
                var temp = t[i];
                if (m.ID == temp.sPID)
                {
                    var child = LoadLevelUserMenu(t, temp);
                    child.AddRange(CreateButtons(temp.Buttons));
                    var menu = new
                    {
                        id = temp.ID,
                        text = temp.sMenuName,
                        state = "open",
                        attributes = new { type = "menu" },
                        @checked = true,
                        children = child
                    };
                    userMs.Add(menu);
                }
            }
            return userMs;
        }

        //创建按钮
        private List<object> CreateButtons(IList<UserMenuButton> t)
        {
            if (t.Count > 0)
            {
                var ret = new List<object>();
                for (int i = 0; i < t.Count; i++)
                {
                    ret.Add(new
                    {
                        id = t[i].ID,
                        @checked = true,
                        attributes = new { type = "btn" },
                        text = t[i].sButtonName,
                        iconCls = t[i].sIcon,
                        state = "open"
                    });
                }
                return ret;
            }
            else
            {
                return new List<object>();
            }
        }
    }
}