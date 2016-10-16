modules.define("enum", [], function Enums() {

    var Enums = {
        //模块名枚举
        Modules: {
            //浏览器版本
            VERSION:"vers",
            //对象操作
            OBJECT:"object",
            //工具模块
            TOOL:"tool",
            //公用发放模块
            FUNC: "func",
            //缓存模块
            CACHE: "cache",
            //集合操作模块
            ARRAY: "array",
            //百度editor模块
            BAIDU_EDITOR: "ue",
            //jquery easy ui 模块
            JQUERY_EASYUI: "eui",
            //MD5加密模块
            MD5_SECURITY: "md5",
            //base64转码模块
            BASE_64: "base64"
        },
        //变量名枚举
        VARIABLE: {
            //百度地图+地址选择的插件选择结果
            BAIDU_MAP_ADDRESS_CHOOSER: "_bcRet",
            //百度editor的上传URL
            UEDITOR_URL: "_ueditorUrl",
            //bootstrap地址选择的数据
            BOOTSTRAP_ADDRESS_DATA:"_bootstrap_address_data"
        }
    };

    window.enums = Enums;
});