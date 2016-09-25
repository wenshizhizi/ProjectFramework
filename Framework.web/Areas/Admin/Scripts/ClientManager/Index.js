$(function () {
    modules.get(enums.Modules.CACHE).setMenuDomain("客户管理", new function () {

        var eui = modules.get(enums.Modules.JQUERY_EASYUI);
        var f = modules.get(enums.Modules.FUNC);
        var grid = $("#client_domain_grid");

        /**
         * 初始化事件
         */
        function initEvent() {            
            //$("#client_domain_form")
            //    .on("click", "a[data-id='search_user_button']", function () { eui.search(grid, true); })
            //    .on("click", "a[data-id='add_systemuser_button']", addSystemUser)
            //    .on("click", "a[data-id='edit_systemuser_button']", editSystemUser)
            //    .on("click", "a[data-id='del_systemuser_button']", delSystemUser)
            //    .on("click", "a[data-id='frozen_systemuser_button']", frozenSystemUser)
            //    .on("click", "a[data-id='distribution_role_to_systemuser']", distributionRoleToSystemuser);
        }

        /**
         * 载入系统用户列表
         * @param {Number} pageNumber 页码
         * @param {Number} pageSize 每页显示条数
         */
        function loadSystemUser(pageNumber, pageSize) {
            try {
                //if ($("#systemuser_form").form("validate")) {
                //    var param/*查询参数*/ = $("#systemuser_form").serializeObject();
                //    param.pageNumber/*当前页码*/ = pageNumber;
                //    param.pageSize/*每页显示条数*/ = pageSize;
                //    f.post("/Admin/SystemUser/LoadSystemUser", param, function (r) {
                //        grid.datagrid("loadData", r.Data.Result);
                //        grid.datagrid("getPager").pagination({
                //            pageNumber: pageNumber,
                //            pageSize: pageSize,
                //            total: r.Data.MaxCount
                //        });
                //    }, function (r) {
                //        eui.alertErr(r.Msg);
                //    });
                //}
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
                toolbar: "#client_domain_grid_tool",
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

        try {
            initData();
            initEvent();
        } catch (e) {
            eui.alertErr(e.message);
        }

        /**
        * 如果你要暴露域接口，请使用以下方式，其他域如果要互动，可以
        * 通过modules.get("cache").getMenuDomain("菜单标题（中文）")
        * 的方式来获取对应的菜单域，并调用他们提供的公共方法，但有一
        * 点请注意，如果提供方法的菜单已经关闭，则无法取到他的操作域
        * */
        //return {
        //    editSystemUser: editSystemUser
        //};
    });
});