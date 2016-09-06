$(function () {

    var eui = modules.get("eui");
    var f = modules.get("func");
    var allMenu = $("#all_menu");

    /**
     * 初始化数据
     */
    function init() {
        allMenu.tree({
            onlyLeafCheck: true,
            checkbox: false,
            lines: true,
            animate: true,
            onContextMenu: function (e, node) {
                //不要执行与事件关联的默认动作
                e.preventDefault();
                //创建菜单
                createMenu(e, node);
            },
            onDblClick: function (node) {
                if (node.state === "closed"){
                    allMenu.tree("expand", node.target);
                } else {
                    allMenu.tree("collapse", node.target);
                }
            }
        });

        f.post("/Admin/MenuManage/LoadAllMenu", null, function (ret) {
            allMenu.tree("loadData", [ret.Data]);
        }, function (ret) {
            eui.alertErr(ret.Msg);
        });

    }

    /**
     * 动态创建右键菜单
     */
    function createMenu(e, node) {

        var menu = $("<div/>");
        //创建右键菜单
        menu.menu({
            align: "left",
            minWidth: 120,
            noline: false,
            hideOnUnhover: false,
            onClick: function () {
                $(this).menu("hide");
                $(this).menu("destroy");
            }
        });

        if (node.attributes.type === "root" || node.attributes.type === "menu") {

            //如果当前菜单是一个节点菜单，没有对应的url，则右键菜单可以添加菜单和编辑菜单、删除菜单
            if (node.attributes.type === "menu" && node.attributes.url.trim().length === 0) {

                //添加菜单节点
                menu.menu("appendItem", {
                    text: '添加菜单',
                    iconCls: 'icon-add',
                    onclick: function () {
                        //添加菜单
                        createAddMenuDialog(node);
                    }
                });

                //编辑菜单节点
                menu.menu("appendItem", {
                    text: '编辑菜单',
                    iconCls: 'icon-edit',
                    onclick: function () {
                        //编辑菜单
                        createEditMenuDialog(node);
                    }
                });

                //删除菜单节点
                menu.menu("appendItem", {
                    text: '删除菜单',
                    iconCls: 'icon-remove',
                    onclick: function () {
                        //删除菜单
                        deleteMenu(node);
                    }
                });
            }
            else if (node.attributes.type === "root") {
                //添加菜单节点
                menu.menu("appendItem", {
                    text: '添加菜单',
                    iconCls: 'icon-add',
                    onclick: function () {
                        //添加菜单
                        createAddMenuDialog(node);
                    }
                });
            }
            else {

                //如果当前节点是有对应url的菜单，则右键菜单可以添加按钮和编辑菜单、删除菜单
                //添加按钮节点
                menu.menu("appendItem", {
                    text: '添加按钮',
                    iconCls: 'icon-add',
                    onclick: function () {
                        //添加按钮
                        createAddButtonDialog(node);
                    }
                });

                //编辑菜单节点
                menu.menu("appendItem", {
                    text: '编辑菜单',
                    iconCls: 'icon-edit',
                    onclick: function () {
                        //编辑菜单
                        createEditMenuDialog(node);
                    }
                });

                //删除菜单节点
                menu.menu("appendItem", {
                    text: '删除菜单',
                    iconCls: 'icon-remove',
                    onclick: function () {
                        //删除菜单
                        deleteMenu(node);
                    }
                });
            }
        } else if (node.attributes.type === "btn") {

            //编辑按钮节点
            menu.menu("appendItem", {
                text: '编辑按钮',
                iconCls: 'icon-edit',
                onclick: function () {
                    //编辑按钮
                    createEditButtonDialog(node);
                }
            });
        }

        //显示菜单
        menu.menu("show", {
            left: e.pageX,
            top: e.pageY
        });
    }

    /**
     * 删除菜单
     * @param {type} node
     */
    function deleteMenu(node) {
        try {
            $.messager.confirm('操作删除菜单', "您是否确认要删除【{0}】？<span style='color:red'>这将造成该菜单下的子菜单和菜单按钮物理删除，对应的角色和个人将无法使用被删除的功能。</span>".format(node.text),
                function (result) {
                    if (result) {
                        f.post("/Admin/MenuManage/DeleteMenu", { ID: node.id }, function (r) {
                            allMenu.tree("remove", node.target);
                            eui.alertMsg("删除成功，请刷新页面以更新菜单");
                        }, function (r) {
                            eui.alertErr(r.Msg);
                        });
                    }
                });
        } catch (e) {
            eui.alertErr(e.message);
        }
    }

    /**
     * 创建编辑菜单的窗口
     * @param {objec} node 菜单节点
     */
    function createEditMenuDialog(node) {
        try {
            var div = $("<div/>");
            div.dialog({
                title: "编辑菜单",
                width: 400,
                height: 200,
                cache: false,
                href: '/Admin/MenuManage/ToEditMenu?id=' + node.id,
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        if ($("#edit_menu_form").form("validate")) {
                            var json = $("#edit_menu_form").serializeObject();
                            f.post("/Admin/MenuManage/EditMenu", json,
                                function (ret) {
                                    allMenu.tree("update", {
                                        target: node.target,
                                        text: ret.Data.text,
                                        id: ret.Data.ID,
                                        attributes: ret.Data.attributes
                                    });
                                    $(div).dialog("close");
                                }, function (ret) {
                                    eui.alertErr(ret.Msg);
                                });
                        }
                    }
                }, {
                    text: '关闭',
                    iconCls: 'icon-cancel',
                    handler: function () {
                        $(div).dialog("close");
                    }
                }],
                onClose: function () {
                    $(div).dialog("destroy");
                },
                onLoad: function () {
                    var form = $("#nodata");
                    if (form.length > 0) {
                        div.parent().find("a>span")[0].remove();
                    }
                }
            });
        } catch (e) {
            eui.alertErr(e.message);
        }
    }

    /**
     * 创建添加菜单的窗口
     * @param {objec} node 菜单节点
     */
    function createAddMenuDialog(node) {
        try {
            var div = $("<div/>");
            div.dialog({
                title: "添加菜单",
                width: 400,
                height: 200,
                cache: false,
                href: '/Admin/MenuManage/ToAddMenu',
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        if ($("#add_menu_form").form("validate")) {
                            var json = $("#add_menu_form").serializeObject();
                            json.sPID = node.id;
                            f.post("/Admin/MenuManage/AddMenu", json,
                                function (ret) {
                                    allMenu.tree("append", {
                                        parent: node.target,
                                        data: [ret.Data]
                                    });
                                    $(div).dialog("close");
                                }, function (ret) {
                                    eui.alertErr(ret.Msg);
                                });
                        }
                    }
                }, {
                    text: '关闭',
                    iconCls: 'icon-cancel',
                    handler: function () {
                        $(div).dialog("close");
                    }
                }],
                onClose: function () {
                    $(div).dialog("destroy");
                }
            });
        } catch (e) {
            eui.alertErr(e.message);
        }
    }

    /**
     * 创建添加按钮的窗口
     * @param {objec} node 菜单节点
     */
    function createAddButtonDialog(node) {
        try {
            var div = $("<div/>");
            div.dialog({
                title: "添加按钮",
                width: 400,
                height: 230,
                cache: false,
                href: '/Admin/MenuManage/ToAddButton',
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        if ($("#add_button_form").form("validate")) {
                            debugger
                            var json = { btn: $("#add_button_form").serializeObject() };
                            json.menuID = node.id;
                            f.post("/Admin/MenuManage/AddButton", json,
                                function (ret) {
                                    allMenu.tree("append", {
                                        parent: node.target,
                                        data: [ret.Data]
                                    });
                                    $(div).dialog("close");
                                }, function (ret) {
                                    eui.alertErr(ret.Msg);
                                });
                        }
                    }
                }, {
                    text: '关闭',
                    iconCls: 'icon-cancel',
                    handler: function () {
                        $(div).dialog("close");
                    }
                }],
                onClose: function () {
                    $(div).dialog("destroy");
                }
            });
        } catch (e) {
            eui.alertErr(e.message);
        }
    }

    /**
     * 创建编辑按钮的窗口
     * @param {objec} node 菜单节点
     */
    function createEditButtonDialog(node) {
        try {
            var div = $("<div/>");
            div.dialog({
                title: "编辑按钮",
                width: 400,
                height: 230,
                cache: false,
                href: '/Admin/MenuManage/ToEditButton?id=' + node.id,
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        if ($("#edit_button_form").form("validate")) {
                            var json = $("#edit_button_form").serializeObject();
                            f.post("/Admin/MenuManage/EditButton", json,
                                function (ret) {
                                    allMenu.tree("update", {
                                        target: node.target,
                                        text: ret.Data.text,
                                        iconCls: ret.Data.iconCls
                                    });
                                    $(div).dialog("close");
                                }, function (ret) {
                                    eui.alertErr(ret.Msg);
                                });
                        }
                    }
                }, {
                    text: '关闭',
                    iconCls: 'icon-cancel',
                    handler: function () {
                        $(div).dialog("close");
                    }
                }],
                onClose: function () {
                    $(div).dialog("destroy");
                },
                onLoad: function () {
                    var form = $("#nodata");
                    if (form.length > 0) {
                        div.parent().find("a>span")[0].remove();
                    }
                }
            });
        } catch (e) {
            eui.alertErr(e.message);
        }
    }

    /**
     * 初始化事件
     */
    function initEvent() {
        //保存菜单按钮
        $("a[data-id='save_menu_btn']").click(function () {
            alert(111);
        });

        //删除菜单按钮
        $("a[data-id='del_menu_btn']").click(function () {
            eui.confirmTreeNode(allMenu, function (selectedNode) {
                if (selectedNode.attributes.type === "menu") {
                    //TODO:删除菜单
                } else {
                    eui.alertErr("您要删除的不是菜单");
                }
            }, null, "请选中你要删除的菜单", function (node) {
                return "您是否确顶要删除{0}？这将使得该菜单无法使用".format(node.text);
            });
        });
    }

    try {
        init();
        initEvent();
    } catch (e) {
        eui.alertErr(e.message);
    }
});