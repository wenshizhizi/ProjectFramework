﻿(function (map) {    
    modules.get("cache").setCache("baidumap", map);
})(new function MapAddressChoose() {
    var areas = modules.get("cache").getCacheNoResident("areas");

    //var clickPoint;

    var map = new BMap.Map("map"); // 创建Map实例

    var point;

    /**
     * 根据经纬度设置地区
     * @param {type} longitude 经度
     * @param {type} latitude 维度
     * @param {type} level 缩放级别
     */
    function loadPlace(longitude, latitude, level) {
        if (parseFloat(longitude) > 0 || parseFloat(latitude) > 0) {

            map.enableScrollWheelZoom(true); //启用滚轮放大缩小

            //向地图中添加缩放控件
            var ctrlNav = new window.BMap.NavigationControl({
                anchor: BMAP_ANCHOR_TOP_LEFT,
                type: BMAP_NAVIGATION_CONTROL_LARGE
            });

            map.addControl(ctrlNav);

            //向地图中添加缩略图控件
            var ctrlOve = new window.BMap.OverviewMapControl({
                anchor: BMAP_ANCHOR_BOTTOM_RIGHT,
                isOpen: 1
            });

            map.addControl(ctrlOve);

            //向地图中添加比例尺控件
            var ctrlSca = new window.BMap.ScaleControl({
                anchor: BMAP_ANCHOR_BOTTOM_LEFT
            });

            map.addControl(ctrlSca);

            level = level || 12;

            //绘制地图
            point = new BMap.Point(longitude, latitude); //地图中心点

            map.centerAndZoom(point, level); // 初始化地图,设置中心点坐标和地图级别。

            map.setCurrentCity("成都");
        }
    }

    function setPlace() {

        remove_overlay();//清除地图上所有覆盖物

        var myGeo/*地址解析对象*/ = new BMap.Geocoder();

        // 将地址解析结果显示在地图上,并调整地图视野
        myGeo.getPoint(document.getElementById('suggestId').value, function (p) {
            if (p) {
                lat = p.lat;
                lng = p.lng;
                map.centerAndZoom(p, 12);
                map.addOverlay(new BMap.Marker(p));
                //alert("地址：" + lat + lng);
            }
            else {
                alert("您输入的地址没有解析到结果!");
            }
        }, document.getElementById('county').value);

    }

    /**
     * 地图点击事件
     */
    map.addEventListener("click", function (e) {
        //alert(e.point.lng + "," + e.point.lat);
        add_overlay(e.point);
    });

    //添加覆盖物
    function add_overlay(clickPoint) {
        var marker = new BMap.Marker(clickPoint); // 创建点
        map.addOverlay(marker);//增加点
    }

    //清除覆盖物
    function remove_overlay() {
        map.clearOverlays();
    }

    function initSelection() {

        //设置默认值
        var option = $("<option>").val("0").text("请选择省份");
        $("[name='province']").append(option);

        option = $("<option>").val("0").text("请选择城市");
        $("[name='city']").append(option);

        option = $("<option>").val("0").text("请选择县区");
        $("[name='county']").append(option);

        //绑定省份
        for (var i = 0; i < areas.length; i++) {
            if (parseInt(areas[i].level) == 1) {
                option = $("<option>").val(areas[i].code).text(areas[i].name);
                $("[name='province']").append(option);
            }
        }

        $("#select_ctrs")
            .on("change", "[name='province']", function () {

                var code = parseInt($(this).val());

                //加载城市
                if (code > 0) {
                    $("[name='city'] option:gt(0)").remove();
                    $("[name='county'] option:gt(0)").remove();
                    for (var i = 0; i < areas.length; i++) {
                        if (parseInt(areas[i].parentCode) == code) {
                            option = $("<option>").val(areas[i].code).text(areas[i].name);
                            $("[name='city']").append(option);
                        }
                    }
                } else {
                    $("[name='city'] option:gt(0)").remove();
                    $("[name='county'] option:gt(0)").remove();
                }
                //绘制地图
                if (code > 0) {
                    for (var i = 0; i < areas.length; i++) {
                        if (parseInt(areas[i].code) == code) {
                            var longitude = areas[i].longitude;
                            var latitude = areas[i].latitude;
                            loadPlace(longitude, latitude, 10);
                            break;
                        }
                    }
                }
            })
            .on("change", "[name='city']", function () {
                var code = parseInt($(this).val());

                //加载县区
                if (code > 0) {
                    $("[name='county'] option:gt(0)").remove();

                    for (var i = 0; i < areas.length; i++) {
                        if (parseInt(areas[i].parentCode) == code) {
                            option = $("<option>").val(areas[i].code).text(areas[i].name);
                            $("[name='county']").append(option);
                        }
                    }
                } else {

                    $("[name='county'] option:gt(0)").remove();
                }

                //绘制地图
                if (code > 0) {
                    for (var i = 0; i < areas.length; i++) {
                        if (parseInt(areas[i].code) == code) {

                            var longitude = areas[i].longitude;
                            var latitude = areas[i].latitude;

                            loadPlace(longitude, latitude, 12);

                            break;
                        }
                    }
                }

            })
            .on("change", "[name='county']", function () {
                var code = parseInt($(this).val());

                //绘制地图
                if (code > 0) {

                    for (var i = 0; i < areas.length; i++) {
                        if (parseInt(areas[i].code) == code) {

                            var longitude = areas[i].longitude;
                            var latitude = areas[i].latitude;

                            loadPlace(longitude, latitude);

                            break;
                        }
                    }
                }
            })
            .on("click", "#baidu_map_choose_search", function (e) {
                debugger
                setPlace();
            })

        return this;
    }

    return {
        loadPlace: loadPlace,
        init: initSelection
    };
});

$(function () {
    modules.get("cache").getCacheNoResident("baidumap").init().loadPlace(104.4, 30.75, 12);
});