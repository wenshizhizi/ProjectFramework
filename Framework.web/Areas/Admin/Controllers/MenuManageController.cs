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
            result.Data = userRoleMenu != null ? CreateMenuData(userRoleMenu.AllMenu) : new object();
        }

        #region 跳转的Action，用于获取部分视图
        /// <summary>
        /// 获取添加菜单的页面
        /// </summary>
        public PartialViewResult ToAddMenu()
        {
            return PartialView("AddMenu");
        }

        /// <summary>
        /// 获取添加按钮的页面
        /// </summary>        
        public PartialViewResult ToAddButton()
        {
            return PartialView("AddButton");
        }
        #endregion

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
            var ret = menubll.AddMenu(menu);

            if (ret != null)
            {
                //返回给页面添加好的菜单对象（tree使用的节点）
                result.Data = new
                {
                    id = ret.ID,
                    text = ret.sMenuName,
                    state = "open",
                    @checked = false,
                    attributes = new { type = "menu", url = ret.sUrl },
                    children = new object[0]
                };

                //从session获取用户的权限和菜单等信息
                var userRoleMenu = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;

                if (userRoleMenu != null)
                {
                    //更新添加的菜单到session缓存
                    userRoleMenu.AllMenu.Add(new UserMenu
                    {
                        Buttons = new List<UserMenuButton>(),
                        ChildMenu = new List<UserMenu>(),
                        ID = ret.ID,
                        iOrder = ret.iOrder,
                        sMenuName = ret.sMenuName,
                        sPID = ret.sPID,
                        sUrl = ret.sUrl
                    });
                }
                else
                {
                    result.Succeeded = false;
                    result.Msg = "会话菜单缓存获取失败";
                    return;
                }

                //重新获取菜单结构
                userRoleMenu.UserMenu = InitMenu(userRoleMenu.AllMenu);

                Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] = userRoleMenu;

                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "添加菜单失败，请联系管理员";
            }
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        public void AddButton()
        {
            var requestData = JSONHelper.GetModel<Dictionary<string, object>>(RequestParameters.data.ToString());
            EHECD_MenuButtonDTO addbutton = JSONHelper.GetModel<EHECD_MenuButtonDTO>(requestData["btn"].ToString());
            string menuID = requestData["menuID"].ToString();
            //菜单业务对象
            IMenuManager menubll = DI.DIEntity.GetInstance().GetImpl<IMenuManager>();
            addbutton = menubll.AddButton(addbutton, menuID);

            if (addbutton != null)
            {
                //从session获取用户的权限和菜单等信息
                var userRoleMenu = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;

                if (userRoleMenu != null)
                {
                    result.Data = new {
                        id = addbutton.ID,
                        @checked = false,
                        attributes = new { type = "btn" },
                        text = addbutton.sButtonName,
                        iconCls = addbutton.sIcon,
                        state = "open"
                    };

                    Parallel.For(0, userRoleMenu.AllMenu.Count, (index, state) =>
                    {
                        if (userRoleMenu.AllMenu[index].ID.ToString() == menuID)
                        {
                            userRoleMenu.AllMenu[index].Buttons.Add(new UserMenuButton
                            {
                                ID = addbutton.ID,
                                iOrder = addbutton.iOrder,
                                sButtonName = addbutton.sButtonName,
                                sDataID = addbutton.sDataID,
                                sIcon = addbutton.sIcon
                            });
                            state.Stop();
                            return;
                        }
                    });

                    //重新获取菜单结构
                    userRoleMenu.UserMenu = InitMenu(userRoleMenu.AllMenu);

                    Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] = userRoleMenu;

                    result.Succeeded = true;
                }
                else
                {
                    result.Succeeded = false;
                    result.Msg = "会话菜单缓存获取失败";
                    return;
                }
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "添加菜单按钮失败，请联系管理员";
            }
        }

        //创建菜单节点数据
        private dynamic CreateMenuData(IList<UserMenu> t)
        {
            var userMs = new List<object>();

            //初始化菜单层级关系
            foreach (var item in t)
            {
                //载入当前菜单的层级关系节点
                var child = LoadLevelUserMenu(t, item);
                //载入当前菜单的按钮
                child.AddRange(CreateButtons(item.Buttons));
                //顶层菜单
                if (item.sPID == null)
                {
                    userMs.Add(new
                    {
                        id = item.ID,
                        text = item.sMenuName,
                        attributes = new { type = "menu", url = "" },
                        @checked = true,
                        state = "open",
                        children = child
                    });
                }
            }

            //给整个菜单创建一个根目录
            return new
            {
                text = "根目录",
                attributes = new { type = "root", url = "" },
                @checked = true,
                state = "open",
                children = userMs
            };
        }

        //载入带层级的菜单节点
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
                        attributes = new { type = "menu", url = temp.sUrl },
                        @checked = true,
                        children = child
                    };
                    userMs.Add(menu);
                }
            }
            return userMs;
        }

        //创建按钮节点
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

        //重新构建菜单层级结构
        private IList<UserMenu> InitMenu(IList<UserMenu> t)
        {
            Parallel.For(0, t.Count, index =>
            {
                t[index].ChildMenu.Clear();
            });

            var userMs = new List<UserMenu>();

            //初始化菜单层级关系
            foreach (var item in t)
            {
                //顶层菜单
                if (item.sPID == null)
                {
                    RecursionLoadLevelUserMenu(t, item);
                    userMs.Add(item);
                }
            }
            return userMs.OrderBy(m => m.iOrder).ToList();
        }

        // 递归从集合中载入指定菜单的下级菜单，直到没有下级菜单        
        private void RecursionLoadLevelUserMenu(IList<UserMenu> t, UserMenu m)
        {
            Parallel.For(0, t.Count, index =>
            {
                var temp = t[index];
                if (m.ID == temp.sPID)
                {
                    m.ChildMenu.Add(temp);
                    RecursionLoadLevelUserMenu(t, temp);
                }
            });
            m.ChildMenu = m.ChildMenu != null ? m.ChildMenu.OrderBy(x => x.iOrder).ToList() : new List<UserMenu>();
        }
    }
}