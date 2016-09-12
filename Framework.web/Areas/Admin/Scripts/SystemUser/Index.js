$(function () {
    void function () {
        var eui = modules.get("eui");
        var t = modules.get("tool");
        var f = modules.get("func");
        var grid = $("#systemuser_grid");

        /**
         * 初始化事件
         */
        function initEvent() {
            $("a[data-id='search_user_button']").click(function () {
                eui.search(grid, true);
            });

            $("a[data-id='add_systemuser_button']").click(addSystemUser);

            $("a[data-id='edit_systemuser_button']").click(editSystemUser);
        }

        /**
         * 载入系统用户列表
         * @param {Number} pageNumber 页码
         * @param {Number} pageSize 每页显示条数
         */
        function loadSystemUser(pageNumber, pageSize) {
            try {
                if ($("#systemuser_form").form("validate")) {
                    var param/*查询参数*/ = $("#systemuser_form").serializeObject();
                    param.pageNumber/*当前页码*/ = pageNumber;
                    param.pageSize/*每页显示条数*/ = pageSize;
                    f.post("/Admin/SystemUser/LoadSystemUser", param, function (r) {
                        grid.datagrid("loadData", r.Data.Result);
                        grid.datagrid("getPager").pagination({
                            pageNumber: pageNumber,
                            pageSize: pageSize,
                            total: r.Data.MaxCount
                        });
                    }, function (r) {
                        eui.alertErr(r.Msg);
                    });
                }
            } catch (e) {
                eui.alertErr(e.message);
            }
        }

        /**
         * 添加用户
         */
        function addSystemUser() {
            var div = $("<div/>");
            div.dialog({
                title: "添加用户",
                width: 500,
                height: 400,
                cache: false,
                href: '/Admin/SystemUser/ToAddSystemUser',
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        if ($("#add_systemuser_form").form("validate")) {

                            var json = $("#add_systemuser_form").serializeObject();

                            if (json.sPassWord !== json.sPassWord2) {
                                return eui.alertErr("两次输入的密码不一致");                                
                            }
                            
                            delete json.sPassWord2;

                            /*
                            * 初始化区域数据
                            */
                            var region = json.region.split("/");

                            if (region.length > 0) {

                                delete json.region;

                                if (region.length === 1) {
                                    json.sProvice = region[0];
                                    json.sCity = "";
                                    json.sCounty = "";
                                } else if (region.length === 2) {
                                    json.sProvice = region[0];
                                    json.sCity = region[1];
                                    json.sCounty = "";
                                } else {
                                    json.sProvice = region[0];
                                    json.sCity = region[1];
                                    json.sCounty = region[2];
                                }
                            } else {
                                return eui.alertErr("请选择系统用户所在区域");                                
                            }

                            f.post("/Admin/SystemUser/AddSystemUser", json,
                                function (ret) {
                                    eui.alertInfo("添加用户成功");
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
        function editSystemUser() {
            eui.checkSelectedRow(grid, function (selectedRow) {
                var div = $("<div/>");
                div.dialog({
                    title: "编辑用户信息",
                    width: 400,
                    height: 200,
                    cache: false,
                    href: '/Admin/SystemUser/ToEditSystemUser',
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
                            //if ($("#edit_role_form").form("validate")) {
                                
                            //    var json = $("#edit_role_form").serializeObject();
                            //    json.ID = selectedRow.ID;
                            //    f.post("/Admin/RoleManage/EditRole", json,
                            //        function (ret) {
                            //            eui.alertInfo("编辑角色成功");
                            //            eui.search(grid, true);
                            //            $(div).dialog("close");
                            //        }, function (ret) {
                            //            eui.alertErr(ret.Msg);
                            //        });
                            //}
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
                toolbar: "#systemuser_grid_tool",
                fit: true,
                fitColumns: true,
                pagination: true,
                rownumbers: true,
                singleSelect: true,
                columns: [[
                { field: 'checkbox', checkbox: true },
                { field: 'sLoginName', title: '登录名', align: 'center', width: 100 },
                { field: 'sUserName', title: '用户名', align: 'center', width: 100 },
                {
                    field: 'tUserState', title: '用户状态', align: 'center', width: 100, formatter: function (value, row, index) {
                        if (row.tUserState === 0) {
                            return "正常";
                        }
                    }
                },
                {
                    field: 'tUserType', title: '用户类型', align: 'center', width: 100, formatter: function (value, row, index) {
                        if (row.tUserType === 0) {
                            return "后台用户";
                        }
                    }
                },
                { field: 'sUserNickName', title: '用户昵称', align: 'center', width: 100 },
                { field: 'dCreateTime', title: '创建时间', align: 'center', width: 100 },
                { field: 'dLastLoginTime', title: '最后登录时间', align: 'center', width: 100 }
                ]],
                onLoadSuccess: function () {
                    $(".datagrid-header-check input[type=checkbox]").remove();
                }
            }, loadSystemUser).pagination("select");
        }

        try {
            initData();
            initEvent();
        } catch (e) {
            eui.alertErr(e.message);
        }
    }();
});