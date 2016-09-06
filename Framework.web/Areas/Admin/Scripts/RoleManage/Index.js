$(function () {
    var eui = modules.get("eui");
    var t = modules.get("tool");
    var f = modules.get("func");
    var grid = $("#role_grid");

    /**
     * 初始化事件
     */
    function initEvent() {
        $("a[data-id='search_role_button']").click(function () {
            eui.search(grid, true);
        });
        $("a[data-id='add_role_button']").click(addRole);
        $("a[data-id='edit_role_button']").click(editRole);
        $("a[data-id='del_role_button']").click(delRole);
    }

    /**
     * 载入角色列表
     * @param {Number} pageNumber 页码
     * @param {Number} pageSize 每页显示条数
     */
    function loadRole(pageNumber, pageSize) {
        try {
            var param/*查询参数*/ = $("#role_form").serializeObject();
            param.pageNumber/*当前页码*/ = pageNumber;
            param.pageSize/*每页显示条数*/ = pageSize;
            f.post("/Admin/RoleManage/LoadRoles", param, function (r) {
                grid.datagrid("loadData", r.Data.Result);
                grid.datagrid("getPager").pagination({
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    total: r.Data.MaxCount
                });
            }, function (r) {
                eui.alertErr(r.message);
            });
        } catch (e) {
            eui.alertErr(e.message);
        }
    }

    /**
     * 添加角色
     */
    function addRole() {
        var div = $("<div/>");
        div.dialog({
            title: "添加角色",
            width: 400,
            height: 200,
            cache: false,
            href: '/Admin/RoleManage/ToAddRole',
            modal: true,
            collapsible: false,
            minimizable: false,
            maximizable: false,
            resizable: false,
            buttons: [{
                text: '保存',
                iconCls: 'icon-save',
                handler: function () {
                    if ($("#add_role_form").form("validate")) {
                        debugger
                        var json = $("#add_role_form").serializeObject();
                        f.post("/Admin/RoleManage/AddRole", json,
                            function (ret) {
                                eui.alertInfo("添加角色成功");
                                eui.search(grid, false);
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
                //var form = $("#nodata");
                //if (form.length > 0) {
                //    div.parent().find("a>span")[0].remove();
                //}
            }
        });
    }

    /**
     * 编辑角色
     */
    function editRole() {
        eui.checkSelectedRow(grid, function (selectedRow) {
            var div = $("<div/>");
            div.dialog({
                title: "编辑角色",
                width: 400,
                height: 200,
                cache: false,
                href: '/Admin/RoleManage/ToEditRole',
                queryParams: selectedRow,
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        if ($("#edit_role_form").form("validate")) {
                            debugger
                            var json = $("#edit_role_form").serializeObject();
                            json.ID = selectedRow.ID;
                            f.post("/Admin/RoleManage/EditRole", json,
                                function (ret) {
                                    eui.alertInfo("编辑角色成功");
                                    eui.search(grid, true);
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
        }, "请选择您要编辑的角色");
    }

    /**
     * 删除角色
     */
    function delRole() {
        try {
            eui.confirmDomain(grid, function (selectedRow) {
                f.post("/Admin/RoleManage/DeleteRole", { ID: selectedRow.ID }, function (r) {
                    eui.alertInfo("删除角色成功");
                    eui.search(grid, false);
                }, function (r) {
                    eui.alertErr(r.Msg);
                });
            }, undefined, "请选择您要删除的角色。",
            function (selectedRow) {
                return "您是否确认要删除【{0}】？<span style='color:red'>该操作是不可逆的！这将造成该拥有该角色用户失去该角色菜单权限和按钮权限，那些用户登录后将没有对应的菜单和按钮。</span>".format(selectedRow.sRoleName);
            });
        } catch (e) {
            eui.alertErr(e.message);
        }
    }

    /**
     * 初始化grid数据
     */
    function initData() {
        eui.bindPaginationEvent(grid, {
            idField: "ID",
            loadMsg: "正在加载...",
            toolbar: "#role_grid_tool",
            fit: true,
            fitColumns: true,
            pagination: true,
            rownumbers: true,
            singleSelect: true,
            columns: [[
            { field: 'checkbox', checkbox: true },
            { field: 'sRoleName', title: '角色名字', align: 'center', width: 100 },
            { field: 'dCreateTime', title: '创建时间', align: 'center', width: 100 },
            { field: 'dModifyTime', title: '修改时间', align: 'center', width: 100 },
            { field: 'iOrder', title: '排序号', align: 'center', width: 100 },
            { field: 'bEnable', title: '是否启用', align: 'center', width: 100 }
            ]],
            onLoadSuccess: function () {
                $(".datagrid-header-check input[type=checkbox]").remove();
            }
        }, loadRole).pagination("select");
    }

    try {
        initData();
        initEvent();
    } catch (e) {
        eui.alertErr(e.message);
    }
});