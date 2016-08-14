$(function () {

    var eui = modules.get("eui");
    var t = modules.get("tool");
    var f = modules.get("func");

    function initEvent() {
        $("td").on("click", function (obj) {
            var index = $(this).attr("data-index");
            var tab = $("#tabs");

            switch (index) {

                case "indexpage":
                    choseTab("首页", tab, "/Admin/MainPage");
                    break;

                case "serpagedeploy":
                    choseTab("服务页面部署", tab, "/Admin/ServicePageDeployment");
                    break;

                case "weixinstore":
                    choseTab("微信商城", tab, "/Admin/WeiXinStore");
                    break;

                case "app":
                    choseTab("APP", tab, "/Admin/App");
                    break

                case "pcmall":
                    choseTab("PC商城", tab, "/Admin/PCMall");
                    break;

                case "weixinaccount":
                    choseTab("微信公众号", tab, "/Admin/WeiXinPublish");
                    break;

                case "dpexperiencepro":
                    choseTab("部署体验项目", tab, "/Admin/ExperienceProject");
                    break;

                case "infomanage":
                    choseTab("资讯管理", tab, "/Admin/InfoManager");
                    break;

                case "accountmanage":
                    choseTab("账号管理", tab, "/Admin/AccountManager");
                    break;

                default:
                    break;
            }
        });
    }

    /**
     * 选择面板
     * @param {string} title
     * @param {tab} tab
     * @param {string} url
     */
    function choseTab(title, tab, url) {
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
                style: { padding:1 }
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