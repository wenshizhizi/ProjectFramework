/**
 * 系统用户操作域 
 * @returns {type} 
 */
function SystemUserDomain() {

    var _parent /*基础操作域*/ = new BaseDomain(),
        _func /*提供通用方法*/ = _parent.func,
        _global /*提供全局变量管理*/ = _parent.cache,
        _easyui /*提供easyui的封装*/ = _parent.jqueryEasyui,
        _variable /*全局变量枚举*/ = _parent.ENUM_VARIABLE,
        domainId /*当前领域模型ID*/ = _parent.func.vertid(),
        domainTitle/*菜单标题*/ = "用户管理",
        sysuserQueryForm /*查询系统用户表单*/ = $("#systemuser_form"),
        sysuserAddForm /*添加系统用户表单*/ = $("#add_systemuser_form"),
        sysuserEditForm /*编辑系统用户表单*/ = $("#edit_systemuser_form"),
        sysuserDistributionForm /*分配角色表单*/ = $("#distribution_role_form"),
        grid /*系统用户列表*/ = $("#systemuser_grid");

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
                    if (sysuserAddForm.form("validate")) {

                        //序列化提交数据
                        var json = sysuserAddForm.serializeObject();

                        //验证密码是否两次输入一致
                        if (json.sPassWord !== json.sPassWord2) {
                            return _easyui.alertErr("两次输入的密码不一致");
                        }

                        delete json.sPassWord2;

                        //初始化区域数据
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
                            return _easyui.alertErr("请选择系统用户所在区域");
                        }

                        _func.post("/Admin/SystemUser/AddSystemUser", json,
                            function (ret) {
                                _easyui.alertInfo("添加用户成功");
                                $(div).dialog("close");
                                _easyui.search(grid, false);
                            }, function (ret) {
                                _easyui.alertErr(ret.Msg);
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
                $(div).dialog("destroy"); div = null;
            },
            onLoad: function () {
            }
        });
    }

    /**
     * 编辑用户
     */
    function editSystemUser() {
        _easyui.checkSelectedRow(grid, function (selectedRow) {
            var div = $("<div/>");
            div.dialog({
                title: "编辑用户信息",
                width: 400,
                height: 400,
                cache: false,
                href: '/Admin/SystemUser/ToEditSystemUser?ID=' + selectedRow.ID,
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,
                buttons: [{
                    text: '保存',
                    iconCls: 'icon-save',
                    handler: function () {
                        if (sysuserEditForm.form("validate")) {

                            //序列化提交数据
                            var json = sysuserEditForm.serializeObject();
                            json.ID = selectedRow.ID;

                            //初始化区域数据
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
                                return _easyui.alertErr("请选择系统用户所在区域");
                            }

                            _func.post("/Admin/SystemUser/EditSystemUser", json,
                                function (ret) {
                                    _easyui.alertInfo("编辑用户成功");
                                    $(div).dialog("close");
                                    _easyui.search(grid, true);
                                }, function (ret) {
                                    _easyui.alertErr(ret.Msg);
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
                    $(div).dialog("destroy"); div = null;
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
     * 删除用户
     */
    function delSystemUser() {
        try {
            _easyui.confirmDomain(grid, function (selectedRow) {
                _func.post("/Admin/SystemUser/DeleteSystemUser",
                    { ID: selectedRow.ID },
                    function (r) {
                        _easyui.alertInfo("删除角色成功");
                        _easyui.search(grid, false);
                    }, function (r) {
                        _easyui.aler(r.Msg);
                    });
            }, undefined, "请选择您要删除的系统用户。",
            function (selectedRow) {
                return "您是否确认要删除【{0}】？<span style='color:red'>该操作是不可逆的！将删除该用户及分配给该用户的所有菜单和按钮。</span>".format(selectedRow.sUserName);
            });
        } catch (e) {
            _easyui.alertErr(e.message);
        }
    }

    /**
     * 冻结用户
     */
    function frozenSystemUser() {
        try {
            _easyui.confirmDomain(grid, function (selectedRow) {
                _func.post("/Admin/SystemUser/FrozenSystemUser",
                    {
                        ID: selectedRow.ID,
                        tUserState: selectedRow.tUserState
                    }, function (r) {
                        if (selectedRow.tUserState === 0) {
                            _easyui.alertInfo("冻结用户成功");
                        } else {
                            _easyui.alertInfo("解冻用户成功");
                        }
                        _easyui.search(grid, true);
                    }, function (r) {
                        _easyui.alertErr(r.Msg);
                    });
            }, undefined, "请选择您要冻结或解冻的系统用户。",
            function (selectedRow) {
                if (selectedRow.tUserState === 0) {
                    return "您是否确认要冻结【{0}】？<span style='color:red'>用户冻结后将不能登录系统。</span>".format(selectedRow.sUserName);
                } else {
                    return "您是否确认要解冻【{0}】？".format(selectedRow.sUserName);
                }
            });
        } catch (e) {
            _easyui.alertErr(e.message);
        }
    }

    /**
     * 分配角色
     */
    function distributionRoleToSystemuser() {
        try {
            _easyui.checkSelectedRow(grid, function (selectedRow) {
                var div = $("<div/>");
                div.dialog({
                    title: "编辑用户信息",
                    width: 400,
                    height: 400,
                    cache: false,
                    href: '/Admin/SystemUser/ToDistributionRole?ID=' + selectedRow.ID,
                    modal: true,
                    collapsible: false,
                    minimizable: false,
                    maximizable: false,
                    resizable: false,
                    buttons: [{
                        text: '保存',
                        iconCls: 'icon-save',
                        handler: function () {
                            if (sysuserDistributionForm.form("validate")) {

                                var rolesIds = "";

                                $("input[data-checkbox='box']:checked")
                                    .each(function () {
                                        rolesIds += $(this).val() + ",";
                                    });

                                if (rolesIds.length > 0) rolesIds = rolesIds.slice(0, rolesIds.length - 1);

                                _func.post("/Admin/SystemUser/DistributionRole?ID=" + selectedRow.ID, { ids: rolesIds },
                                    function (ret) {
                                        _easyui.alertInfo("分配用户角色成功");
                                        $(div).dialog("close");
                                        _easyui.search(grid, true);
                                    }, function (ret) {
                                        _easyui.alertErr(ret.Msg);
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
                        $(div).dialog("destroy"); div = null;
                    },
                    onLoad: function () {
                        var form = $("#nodata");
                        if (form.length > 0) {
                            div.parent().find("a>span")[0].remove();
                        }
                    }
                });
            }, "请选择要分配角色的用户");
        } catch (e) {
            _easyui.alertErr(e.message);
        }
    }

    /**
     * 初始化grid数据
     */
    function initData() {
        _easyui.bindPaginationEvent(grid, {
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
                    switch (row.tUserState) {
                        case 0:
                            return "正常";
                        case 1:
                            return "冻结";
                        default:
                            break;
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
            { field: 'sMobileNum', title: '手机号', align: 'center', width: 100 },
            { field: 'dCreateTime', title: '创建时间', align: 'center', width: 100 },
            { field: 'dLastLoginTime', title: '最后登录时间', align: 'center', width: 100 }
            ]],
            onLoadSuccess: function () {
                $(".datagrid-header-check input[type=checkbox]").remove();
            }, rowStyler: function (index, row) {
                if (row.tUserState === 1) {
                    return 'background-color:gray;color:white';
                }
            }
        }, loadSystemUser).pagination("select");
    }

    /**
     * 载入系统用户列表
     * @param {Number} pageNumber 页码
     * @param {Number} pageSize 每页显示条数
     */
    function loadSystemUser(pageNumber, pageSize) {
        try {
            if (sysuserQueryForm.form("validate")) {
                var param/*查询参数*/ = sysuserQueryForm.serializeObject();
                param.pageNumber/*当前页码*/ = pageNumber;
                param.pageSize/*每页显示条数*/ = pageSize;
                _func.post("/Admin/SystemUser/LoadSystemUser", param, function (r) {
                    grid.datagrid("loadData", r.Data.Result);
                    grid.datagrid("getPager").pagination({
                        pageNumber: pageNumber,
                        pageSize: pageSize,
                        total: r.Data.MaxCount
                    });
                }, function (r) {
                    _easyui.alertErr(r.Msg);
                });
            }
        } catch (e) {
            _easyui.alertErr(e.message);
        }
    }

    /**
     * 绑定事件
     */
    function initEvent() {
        $("#systemuser_grid_tool")
            .on("click", "a[data-id='search_user_button']", function () { _easyui.search(grid, true) })
            .on("click", "a[data-id='add_systemuser_button']", addSystemUser)
            .on("click", "a[data-id='edit_systemuser_button']", editSystemUser)
            .on("click", "a[data-id='del_systemuser_button']", delSystemUser)
            .on("click", "a[data-id='frozen_systemuser_button']", frozenSystemUser)
            .on("click", "a[data-id='distribution_role_to_systemuser']", distributionRoleToSystemuser);
    }

    /**
     * 文档初始好后执行
     */
    try {
        initData();
        initEvent();
    } catch (e) {
        _easyui.alertErr(e.message);
    }

    /**
     * 销毁对象资源（处理内部资源，供外部调用，请务必实现）
     */
    function destory() {
        _global.cleanCache(_variable.BOOTSTRAP_ADDRESS_DATA);
    }

    /*
    * 暴露的接口
    */
    return {
        //领域id
        id: domainId,
        //菜单标题
        title:domainTitle,
        //释放资源
        destory: destory
    };
}

$(function () {
    var domain = new SystemUserDomain();    
    modules.get(enums.Modules.CACHE).setMenuDomain({
        id: domain.id,
        title: domain.title,
        domain:domain
    });
});