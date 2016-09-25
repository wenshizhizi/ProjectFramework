$(function () {
    void function () {

        var f = modules.get(enums.Modules.FUNC);/*方法模块*/
        var eui = modules.get(enums.Modules.JQUERY_EASYUI);/*easyui模块*/
        var btn_reset = $("#btn_reset");/*重置按钮*/
        var btn_lgon = $("#btn_lgon");/*登录按钮*/
        var code = $("#vcodepic");/*验证码框*/
        var loginPanel = $("#lg_panel");/*登录窗口*/

        //初始化登录框位置
        function initLoginPanel() {

            var windowHeight = window.innerHeight;/*窗体高度*/
            var windowWidth = window.innerWidth;/*窗体宽度*/
            var panelWidth = loginPanel.panel("options").width;/*登录窗体宽度*/
            var panelHeight = loginPanel.panel("options").height;/*登录窗体高度*/

            //计算左边距
            var left = (windowWidth - panelWidth) > 0 ? (windowWidth - panelWidth) / 2 : 0;

            //计算右边距
            var top = (windowHeight - panelHeight) > 0 ? (windowHeight - panelHeight) / 2 : 0;

            //设置登录窗口位置
            loginPanel.panel("move", { left: left, top: top });
        }

        /**
         * 登录系统
         */
        function loginSystem() {

            var ln = $("#uname").textbox("getText");/*登录名*/

            if (ln === "请输入登录名") {
                $("#uname").textbox("clear");
                $("#lg_form").form("validate");
                return;
            }

            if ($("#lg_form").form("validate")) {

                var lp = $("#upwd").textbox("getText");/*密码*/
                var vc = $("#vcode").textbox("getText");/*验证码*/

                f.post("/Admin/Login/Login", { sLoginName: ln, sPassWord: lp, sUserName: vc }, function (r) {
                    window.location = r.Data;
                }, function (r) {
                    eui.alertMsg(r.Msg);
                });
            }
        }

        /**
         * 初始化验证码
         */
        function initVCode() {
            f.post("/ValidateCode/VCode?" + new Date(), null, function (result) {
                code.attr("src", result.Data);
            }, function (result) {
                alert(result.Msg);
            }, false);
        }

        /**
         * 绑定事件
         */
        function bindElementEvent() {

            //window窗体改变大小时重新定位登录窗口位置
            $(window).on("resize", initLoginPanel);

            //点击验证码获取新的验证码
            code.on("click", initVCode);

            //登录名输入框获取焦点去掉默认的值
            $("#uname").textbox("textbox").on("focus", function () {
                if ($("#uname").textbox("getText").indexOf("请输入登录名") >= 0)
                    $("#uname").textbox("clear");
            });

            //登录名输入框失去焦点如果没有输入则设置默认值
            $("#uname").textbox("textbox").on("blur", function () {
                if ($("#uname").textbox("getText").length <= 0)
                    $("#uname").textbox("setText", "请输入登录名");
            });

            //密码输入框获取焦点去掉默认的值
            $("#upwd").textbox("textbox").on("focus", function () {
                if ($("#upwd").textbox("getText").length > 0)
                    $("#upwd").textbox("clear");
            });

            //密码输入框失去焦点如果没有输入则设置默认值
            $("#upwd").textbox("textbox").on("blur", function () {
                if ($("#upwd").textbox("getText").length === 0)
                    $("#upwd").textbox("setText", "123");
            });

            //验证码输入框获取焦点去掉默认的值
            $("#vcode").textbox("textbox").on("focus", function () {
                if ($("#vcode").textbox("getText").indexOf("请输入验证码") >= 0)
                    $("#vcode").textbox("clear");
            });

            //验证码输入框失去焦点如果没有输入则设置默认值
            $("#vcode").textbox("textbox").on("blur", function () {
                if ($("#vcode").textbox("getText").length <= 0)
                    $("#vcode").textbox("setText", "请输入验证码");
            });

            //重置按钮
            btn_reset.on("click", function () {
                $("#uname").textbox("reset");
                $("#upwd").textbox("reset");
                $("#vcode").textbox("reset");
            });

            //登录
            btn_lgon.on("click", loginSystem);
        }

        //初始化
        try {
            initLoginPanel();
            initVCode();
            bindElementEvent();
        } catch (e) {
            eui.alertErr(e.message);
        }
    }();
});