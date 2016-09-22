$(function () {
    var f = modules.get(enums.Modules.FUNC);
    var eui = modules.get(enums.Modules.JQUERY_EASYUI);
    f.post("/Admin/Main/GetServerUrl", null, function (r) {
        modules.get(enums.Modules.CACHE).setCache(enums.VARIABLE.UEDITOR_URL, r.Data);
    }, function (r) {
        eui.alertErr(r.Msg);
    });
});