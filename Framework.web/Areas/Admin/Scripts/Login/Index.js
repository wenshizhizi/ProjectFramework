$(function () {

    var f/*方法模块*/ = modules.get(enums.Modules.FUNC);
    var eui/*easyui模块*/ = modules.get(enums.Modules.JQUERY_EASYUI);
    var btn_reset/*重置按钮*/ = $("#btn_reset");
    var btn_lgon/*登录按钮*/ = $("#btn_lgon");
    var code/*验证码框*/ = $("#vcodepic");
    var loginPanel/*登录窗口*/ = $("#lg_panel");

    /**
     * 初始化登录框位置
     */
    function initLoginPanel() {
        try {
            var windowHeight/*窗体高度*/ = window.innerHeight;
            var windowWidth/*窗体宽度*/ = window.innerWidth;
            var panelWidth/*登录窗体宽度*/ = loginPanel.panel("options").width;
            var panelHeight/*登录窗体高度*/ = loginPanel.panel("options").height;
            var left/*左边距*/ = (windowWidth - panelWidth) > 0 ? (windowWidth - panelWidth) / 2 : 0;
            var top/*右边距*/ = (windowHeight - panelHeight) > 0 ? (windowHeight - panelHeight) / 2 : 0;

            //设置登录窗口位置
            loginPanel.panel("move", { left: left, top: top });
        } catch (e) {
            eui.alertErr(e.message);
        }
    }

    /**
     * 登录系统
     */
    function loginSystem() {

        var ln/*登录名*/ = $("#uname").textbox("getText");

        if (ln.indexOf("请输入登录名") > -1) {
            $("#uname").textbox("clear");
            $("#lg_form").form("validate");
            return;
        }

        if ($("#lg_form").form("validate")) {

            var lp/*密码*/ = $("#upwd").textbox("getText");
            var vc/*验证码*/ = $("#vcode").textbox("getText");

            f.post("/Admin/Login/Login",
                {
                    sLoginName: ln, sPassWord: lp, sUserName: vc
                },
                function (r) {
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
        f.post("/ValidateCode/VCode?" + new Date(),
            null,
            function (result) {
                code.attr("src", result.Data);
            }, function (result) {
                eui.alertErr(result.Msg);
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

        //忘记密码
        $("#forget_psd").on("click", function () {
            var div = $("<div/>");            
            div.dialog({
                title: "找回密码",
                width: 400,
                height: 300,
                cache: false,
                href: '/Admin/Login/ToForgetPWD',
                modal: true,
                collapsible: false,
                minimizable: false,
                maximizable: false,
                resizable: false,                     
                buttons: [{
                    text: '确定',
                    iconCls: 'icon-save',
                    handler: function () {
                        //if ($("#forget_pwd_form").form("validate")) {

                        //    //序列化提交数据
                        //    var json = $("#form的id，请自行替换").serializeObject();

                        //    f.post("提交地址", json,
                        //        function (ret) {
                        //            eui.alertInfo("成功的提示");
                        //            $(div).dialog("close");
                        //            eui.search(grid, false);
                        //        }, function (ret) {
                        //            eui.alertErr(ret.Msg);
                        //        });
                        //}
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
        });

        //登录
        btn_lgon.on("click", loginSystem);
    }

    //初始化
    try {
        initLoginPanel/*初始化登录框位置*/();
        initVCode/*初始化验证码*/();
        bindElementEvent/*绑定事件*/();
    } catch (e) {
        eui.alertErr(e.message);
    }
});