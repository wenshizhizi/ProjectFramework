$(function () {
    modules.get("cache").setMenuDomain("商品分类管理", new function () {

        var eui = modules.get("eui");
        var f = modules.get("func");


        /**
         * 初始化事件
         */
        function initEvent() {
            $("#goods_category_form")
                .on("click", "a[data-id='add_goods_category']", addGoodsCategory)
                .on("click", "a[data-id='edit_goods_category']", editGoodsCategory)
                .on("click", "a[data-id='del_goods_category']", deleteGoodsCategory);
        }

        /**
         * 添加商品分类
         */
        function addGoodsCategory() {
            eui.alertInfo(111);
        }

        /**
         * 编辑商品分类
         */
        function editGoodsCategory() {
            eui.alertInfo(111);
        }

        /**
         * 删除商品分类
         */
        function deleteGoodsCategory() {
            eui.alertInfo(111);
        }

        /**
         * 初始化tree数据
         */
        function initData() {
            $("#goods_category_tree").treegrid({
                idField: "id",
                fit: true,
                treeField: "text",
                animate: true,
                border: false,
                fitColumns: true,
                rownumbers: true,
                columns: [[
                    { field: 'sPID', hidden: true },
                    { title: '商品种类名称', field: 'text', width: 100 },
                    { title: '商品种类简述', field: 'sCategoryCaption', align: 'center', width: 100 },
                    {
                        title: '分类图标', field: 'sImgUri', align: 'center', width: 100, formatter: function (value, row, index) {
                            var ret = "<img src='" + (value === "" ? "../Content/img/noimg.png" : value) + "' style='height:40px;width:100px;'></img>";
                            return ret;
                        }
                    },
                    { title: '添加时间', field: 'addDate', align: 'center', width: 100 },
                    { title: '排序号', field: 'iOrder', align: 'center', width: 100 }
                ]]
            });
            try {
                f.post("/Admin/GoodsCategory/LoadGoodsCategory", null, function (r) {
                    $("#goods_category_tree").treegrid("loadData", r.Data);
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