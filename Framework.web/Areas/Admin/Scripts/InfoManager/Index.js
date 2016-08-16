$(function () {

    var f = modules.get("func");
    var eui = modules.get("eui");

    function init() {

        eui.bindPaginationEvent($('#info_grid'),
            {
                idField: "ID",
                fit: true,
                loadMsg: "加载中...",
                //toolbar: "#cartype_grid_tools",
                pagination: true,
                fitColumns: true,
                rownumbers: true,
                singleSelect: true,
                columns: [[
                   { field: 'checkbox', checkbox: true },
                   { field: 'sRealName', title: '姓名', width: 100, align: 'center' },
                   { field: 'sLoginName', title: '登录名', width: 100, align: 'center' },
                   { field: 'iType', title: '员工类型', width: 100, align: 'center' }
                ]],
                onLoadSuccess: function () {
                    $(".datagrid-header-check input[type=checkbox]").remove();
                }
            }, loadData).pagination("select");
    }



    function loadData(pageNumber, pageSize) {
        f.post("/Admin/AccountManager/LoadAccounts", { PageIndex: pageNumber, PageSize: pageSize }, function (r) {

            $('#info_grid').datagrid("loadData", r.Data.Result);
            $('#info_grid').datagrid("getPager").pagination({
                pageNumber: pageNumber,
                pageSize: pageSize,
                total: r.Data.MaxCount
            });

        }, function (r) {
        });
    }

    init();
});