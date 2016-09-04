$(function () {
    var eui = modules.get("eui");
    var t = modules.get("tool");
    var f = modules.get("func");
    var grid = $("#role_grid");


    function initEvent() {
        $("a[data-id='search_rol_button']").click(function () {
            eui.search(grid, true);
        });
        $("a[data-id='add_role_button']").click(addRole);
        $("a[data-id='edit_role_button']").click(editRole);
        $("a[data-id='del_role_button']").click(delRole);
    }

    function loadRole(pageNumber, pageSize) {
        try {
            var param = $("#role_form").serializeObject();
            param.pageNumber = pageNumber;
            param.pageSize = pageSize;
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

    function addRole() {
        alert("addRole");
    }

    function editRole() {
        alert("editRole");
    }

    function delRole() {
        alert("delRole");
    }

    function initData() {
        eui.bindPaginationEvent(grid, {
            idField: "ID",
            loadMsg: "正在加载...",
            toolbar: "#role_grid_tool",
            fit: true,
            fitColumns: true,
            pagination: true,
            rownumbers: true,
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