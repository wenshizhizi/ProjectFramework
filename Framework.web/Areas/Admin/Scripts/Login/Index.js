$(function () {

    var f = modules.get("func");
    var btn_reset = $("#btn_reset");
    var btn_lgon = $("#btn_lgon");
    var code = $("#vcodepic");
    var loginPanel = $("#lg_panel");
    var eui = modules.get("eui");
    
    //初始化登录框位置
    function initLoginPanel() {
        var windowHeight = window.innerHeight;
        var windowWidth = window.innerWidth;
        var panelWidth = loginPanel.panel("options").width;
        var panelHeight = loginPanel.panel("options").height;

        var left = (windowWidth - panelWidth) > 0 ? (windowWidth - panelWidth) / 2 : 0;
        var top = (windowHeight - panelHeight) > 0 ? (windowHeight - panelHeight) / 2 : 0;

        loginPanel.panel("move", { left: left, top: top });
    }

    //登录系统
    function loginSystem() {
        //debugger
        var ln = $("#uname").textbox("getText");

        if (ln === "请输入登录名") {
            $("#uname").textbox("clear");
            $("#lg_form").form("validate");
            return;
        }

        if ($("#lg_form").form("validate")) {
            var lp = $("#upwd").textbox("getText");
            var vc = $("#vcode").textbox("getText");

            f.post("/Admin/Login/Login", { sLoginName: ln, sLoginPwd: lp, sRealName: vc }, function (r) {
                window.location = r.Data;
            }, function (r) {
                eui.alertMsg(r.Msg);
            });
        }
    }

    //初始化验证码
    function initVCode() {
        f.post("/ValidateCode/VCode?" + new Date(), null, function (result) {
            code.attr("src", result.Data);
        }, function (result) {
            alert(result.Msg);
        }, false);
    }

    //绑定事件
    function bindElementEvent() {
              
        $(window).on("resize", initLoginPanel);

        code.on("click", initVCode);

        $("#uname").textbox("textbox").on("focus", function () {
            if ($("#uname").textbox("getText").indexOf("请输入登录名") >= 0)
                $("#uname").textbox("clear");
        });

        $("#uname").textbox("textbox").on("blur", function () {
            if ($("#uname").textbox("getText").length <= 0)
                $("#uname").textbox("setText", "请输入登录名");
        });

        $("#upwd").textbox("textbox").on("focus", function () {
            if ($("#upwd").textbox("getText").length > 0)
                $("#upwd").textbox("clear");
        });

        $("#upwd").textbox("textbox").on("blur", function () {
            if ($("#upwd").textbox("getText").length === 0)
                $("#upwd").textbox("setText", "123");
        });

        $("#vcode").textbox("textbox").on("focus", function () {
            if ($("#vcode").textbox("getText").indexOf("请输入验证码") >= 0)
                $("#vcode").textbox("clear");
        });

        $("#vcode").textbox("textbox").on("blur", function () {
            if ($("#vcode").textbox("getText").length <= 0)
                $("#vcode").textbox("setText", "请输入验证码");
        });

        btn_reset.on("click", function () {
            $("#uname").textbox("reset");
            $("#upwd").textbox("reset");
            $("#vcode").textbox("reset");
        });

        btn_lgon.on("click", loginSystem);
    }
        
    try {
        initLoginPanel();
        initVCode();
        bindElementEvent();
    } catch (e) {
        eui.alertErr(e.message);
    }
});