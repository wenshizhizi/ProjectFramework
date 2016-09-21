$(function () {
    modules.get("cache").setMenuDomain("商品分类管理", new function () {

        var eui = modules.get("eui");
        var f = modules.get("func");
        

        /**
         * 初始化事件
         */
        function initEvent() {
            //$("#systemuser_grid_tool")
            //    .on("click", "a[data-id='search_user_button']", function () { eui.search(grid, true); })
            //    .on("click", "a[data-id='add_systemuser_button']", addSystemUser)
            //    .on("click", "a[data-id='edit_systemuser_button']", editSystemUser)
            //    .on("click", "a[data-id='del_systemuser_button']", delSystemUser)
            //    .on("click", "a[data-id='frozen_systemuser_button']", frozenSystemUser)
            //    .on("click", "a[data-id='distribution_role_to_systemuser']", distributionRoleToSystemuser);
        }

        /**
         * 初始化tree数据
         */
        function initData() {
            try {
                f.post("/Admin/GoodsCategory/LoadGoodsCategory", null, function (r) {                    
                    $("#goods_category_tree").tree("loadData",r.Data);
                }, function (r) {
                    eui.alertErr(r.Msg);
                });
            } catch (e) {
                eui.alertErr(e.message);
            }
        }

        try {
            initData();
            initEvent();
        } catch (e) {
            eui.alertErr(e.message);
        }
    });
});