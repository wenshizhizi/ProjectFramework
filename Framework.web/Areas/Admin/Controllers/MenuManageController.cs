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
using Framework.Helper;

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

        /// <summary>
        /// 获取编辑按钮的页面
        /// </summary> 
        public PartialViewResult ToEditButton(string id)
        {
            UserMenuButton btn = LoadMenuButtonById(id);
            return PartialView("EditButton", btn);
        }

        /// <summary>
        /// 获取编辑菜单的页面
        /// </summary>
        public PartialViewResult ToEditMenu(string id)
        {
            UserMenu menu = LoadMenuById(id);
            return PartialView("EditMenu", menu);
        }
        #endregion

        #region 操作方法（编辑、添加）
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
                    result.Data = new
                    {
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

        /// <summary>
        /// 编辑按钮
        /// </summary>
        public void EditButton()
        {
            EHECD_MenuButtonDTO editbutton = JSONHelper.GetModel<EHECD_MenuButtonDTO>(RequestParameters.dataStr);

            editbutton = DI.DIEntity.GetInstance().GetImpl<IMenuManager>().EditButton(editbutton);

            if (editbutton != null)
            {
                var ret = new UserMenuButton
                {
                    ID = editbutton.ID,
                    iOrder = editbutton.iOrder,
                    sButtonName = editbutton.sButtonName,
                    sDataID = editbutton.sDataID,
                    sIcon = editbutton.sIcon
                };

                UpdateSessionMenuButton(ret);

                result.Data = new
                {
                    id = ret.ID,
                    @checked = true,
                    attributes = new { type = "btn" },
                    text = ret.sButtonName,
                    iconCls = ret.sIcon,
                    state = "open"
                };

                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "编辑菜单按钮失败，请联系管理员";
            }
        }

        /// <summary>
        /// 编辑菜单
        /// </summary>
        public void EditMenu()
        {
            EHECD_FunctionMenuDTO menu = JSONHelper.GetModel<EHECD_FunctionMenuDTO>(RequestParameters.dataStr);
            var editmenu = DI.DIEntity.GetInstance().GetImpl<IMenuManager>().EditMenu(menu);
            if (editmenu != null)
            {
                UpdateSessionMenu(editmenu);

                result.Data = new
                {
                    id = editmenu.ID,
                    attributes = new { type = "menu", url = editmenu.sUrl },
                    text = editmenu.sMenuName
                };

                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "编辑菜单失败，请联系管理员";
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        public void DeleteMenu()
        {
            EHECD_FunctionMenuDTO menu = JSONHelper.GetModel<EHECD_FunctionMenuDTO>(RequestParameters.dataStr);
            var editmenu = DI.DIEntity.GetInstance().GetImpl<IMenuManager>().DeleteMenu(menu);
            if (editmenu > 0)
            {
                DeleteSessionMenu(menu.ID.ToString());
                result.Succeeded = true;
            }
            else
            {
                result.Succeeded = false;
                result.Msg = "删除菜单失败，请联系管理员";
            }
        }

        #endregion

        #region 私有方法（主要是操作session中的菜单哪一类的）
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
                        attributes = new { type = "menu", url = "", order = item.iOrder },
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
                attributes = new { type = "root", url = "", order = 0 },
                @checked = true,
                state = "open",
                children = userMs.OrderBy(m => ((dynamic)((dynamic)m).attributes).order).ToList()
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
                    //载入他的下级节点
                    var child = LoadLevelUserMenu(t, temp);
                    //载入他的菜单按钮
                    child.AddRange(CreateButtons(temp.Buttons.OrderBy(mx => mx.iOrder).ToList()));
                    var menu = new
                    {
                        id = temp.ID,
                        text = temp.sMenuName,
                        state = "open",
                        attributes = new { type = "menu", url = temp.sUrl, order = temp.iOrder },
                        @checked = true,
                        children = child
                    };
                    userMs.Add(menu);
                }
            }
            return userMs.OrderBy(km => ((dynamic)((dynamic)km).attributes).order).ToList();
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
                        attributes = new { type = "btn", order = t[i].iOrder },
                        text = t[i].sButtonName,
                        iconCls = t[i].sIcon,
                        state = "open"
                    });
                }
                return ret.OrderBy(km => ((dynamic)((dynamic)km).attributes).order).ToList();
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

        //找到指定的按钮信息
        private UserMenuButton LoadMenuButtonById(string id)
        {
            UserMenuButton ret = null;
            var userRoleMenu = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;

            if (userRoleMenu != null)
            {
                var isfind = false;
                Parallel.For(0, userRoleMenu.AllMenu.Count, (index, state) =>
                {
                    if (isfind)
                    {
                        state.Stop();
                        return;
                    }
                    else
                    {
                        Parallel.ForEach<UserMenuButton>(userRoleMenu.AllMenu[index].Buttons, (button, innerstate) =>
                        {
                            if (button.ID.ToString() == id)
                            {
                                ret = button;
                                isfind = true;
                                innerstate.Stop();
                                return;
                            }
                        });
                    }
                });
            }

            return ret;
        }

        //找到指定的菜单信息
        private UserMenu LoadMenuById(string id)
        {
            UserMenu ret = null;
            var userRoleMenu = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;
            if (userRoleMenu != null)
            {
                Parallel.For(0, userRoleMenu.AllMenu.Count, (index, state) =>
                {
                    if (userRoleMenu.AllMenu[index].ID.ToString() == id)
                    {
                        ret = userRoleMenu.AllMenu[index];
                        state.Stop();
                        return;
                    }
                });
            }
            return ret;

        }

        //更新会话中的按钮
        private void UpdateSessionMenuButton(UserMenuButton m)
        {
            var userRoleMenu = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;

            if (userRoleMenu != null)
            {
                var isfind = false;
                Parallel.For(0, userRoleMenu.AllMenu.Count, (index, state) =>
                {
                    if (isfind)
                    {
                        state.Stop();
                        return;
                    }
                    else
                    {
                        Parallel.For(0, userRoleMenu.AllMenu[index].Buttons.Count, (innerindex, innerstate) =>
                        {
                            if (userRoleMenu.AllMenu[index].Buttons[innerindex].ID == m.ID)
                            {
                                userRoleMenu.AllMenu[index].Buttons[innerindex] = m;
                                userRoleMenu.AllMenu = userRoleMenu.AllMenu.OrderBy(mx => mx.iOrder).ToList();
                                isfind = true;
                                innerstate.Stop();
                                return;
                            }
                        });
                    }
                });
            }
            else
            {
                throw new Domain.DomainInfoException("没有从会话中找到对应的按钮，请联系管理员");
            }
        }

        //更新会话中的菜单
        private void UpdateSessionMenu(EHECD_FunctionMenuDTO editmenu)
        {
            var userRoleMenu = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;

            if (userRoleMenu != null)
            {
                Parallel.For(0, userRoleMenu.AllMenu.Count, (index, state) =>
                {
                    if (userRoleMenu.AllMenu[index].ID == editmenu.ID)
                    {
                        userRoleMenu.AllMenu[index].iOrder = editmenu.iOrder;
                        userRoleMenu.AllMenu[index].sMenuName = editmenu.sMenuName;
                        userRoleMenu.AllMenu[index].sUrl = editmenu.sUrl;
                        state.Stop();
                        return;
                    }
                });
                var userMenu = InitMenu(userRoleMenu.AllMenu);
                userRoleMenu.UserMenu = userMenu;
                Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] = userRoleMenu;
            }
            else
            {
                throw new Domain.DomainInfoException("没有从会话中找到对应的菜单，请联系管理员");
            }
        }

        //删除session中的menu
        private void DeleteSessionMenu(string v)
        {
            var userRoleMenu = Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] as UserRoleMenuInfo;
            if (userRoleMenu != null)
            {
                var temp = RecursionLoadMenus(userRoleMenu.AllMenu, new UserMenu { ID = Guid.Parse(v) });

                temp.Add(new UserMenu { ID = Guid.Parse(v) });

                for (int i = 0; i < temp.Count; i++)
                {
                    var id = temp[i].ID;

                    Parallel.For(0, userRoleMenu.AllMenu.Count, (index, state) =>
                    {
                        if (userRoleMenu.AllMenu[index].ID == id)
                        {
                            userRoleMenu.AllMenu.RemoveAt(index);
                            state.Stop();
                            return;
                        }
                    });
                }

                var userMenu = InitMenu(userRoleMenu.AllMenu);
                userRoleMenu.UserMenu = userMenu;
                Session[SessionInfo.USER_MENUS/*用户的权限和菜单等信息*/] = userRoleMenu;
            }
            else
            {
                throw new Domain.DomainInfoException("没有从会话中找到对应的菜单，请联系管理员");
            }
        }

        /// <summary>
        /// 递归载入菜单
        /// </summary>
        /// <param name="t"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private IList<UserMenu> RecursionLoadMenus(IList<UserMenu> t, UserMenu m)
        {
            List<UserMenu> ret = new List<UserMenu>();
            Parallel.For(0, t.Count, index =>
            {
                var temp = t[index];
                if (m.ID == temp.sPID)
                {
                    ret.Add(temp);
                    ret.AddRange(RecursionLoadMenus(t, temp));
                }
            });
            return ret;
        }
        #endregion
    }
}