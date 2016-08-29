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
            onContextMenu: function (e, node) {
                //不要执行与事件关联的默认动作
                e.preventDefault();
                //创建菜单
                createMenu(e, node);
            }
        });

        f.post("/Admin/MenuManage/LoadAllMenu", null, function (ret) {
            debugger
            allMenu.tree("loadData", [ret.Data]);
        }, function (ret) {
            eui.alertErr(ret.Msg);
        });

    }

    /**
     * 动态创建右键菜单
     */
    function createMenu(e, node) {
        if (node.attributes.type === "root" || node.attributes.type === "menu") {
            var menu = $("<div/>");
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
            menu.menu("appendItem", {
                text: '添加菜单',
                iconCls: 'icon-add',
                onclick: function () {
                    //添加菜单
                    createAddMenuDialog(node);
                }
            });
            if (node.attributes.type === "menu") {
                menu.menu("appendItem", {
                    text: '添加按钮',
                    iconCls: 'icon-add',
                    onclick: function () {
                        //添加按钮
                    }
                });
                menu.menu("appendItem", {
                    text: '编辑菜单',
                    iconCls: 'icon-edit',
                    onclick: function () {
                        //编辑菜单
                    }
                });
            }
            menu.menu("show", {
                left: e.pageX,
                top: e.pageY
            });
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