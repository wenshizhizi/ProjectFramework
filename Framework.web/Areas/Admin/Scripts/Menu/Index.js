$(function () {

    var eui = modules.get("eui");
    var t = modules.get("tool");
    var f = modules.get("func");
    var mainTab = $("#tabs");

    /**
     * 初始化事件
     * 绑定菜单按钮事件
     */
    function initEvent() {
        $("td[data-link]").each(function () {

            var data = {
                url:
                    $(this).attr("data-link"),
                title:
                    $(this).attr("data-title")
            };

            $(this).click(data, function (event) {
                choseTab(event.data.title, mainTab, event.data.url);
            });
        });
    }

    /**
     * 选择面板
     * @param {string} title
     * @param {tab} tab
     * @param {string} url
     */
    function choseTab(title, tab, url) {
        debugger
        var extab = tab.tabs("getTab", title);
        if (!f.definededAndNotNull(extab)) {
            var count = tab.tabs("tabs").length;
            if (count >= 8) {
                tab.tabs("close", 0);
            }

            tab.tabs("add", {
                title: title,
                cache: true,
                closable: true,
                href: url,
                justified: true,
                style: { padding: 1 }
            });
        } else {
            var index = tab.tabs("getTabIndex", extab);
            tab.tabs("select", index);
        }
    }

    try {
        initEvent();
    } catch (e) {
        eui.alertErr(e.message);
    }
});