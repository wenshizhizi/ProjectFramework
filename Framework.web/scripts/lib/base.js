
function BaseDomain() {

    var MODULE = enums.Modules;
    var VARIABLE = enums.VARIABLE;

    this.ENUM_MODULE = MODULE;
    this.ENUM_VARIABLE = VARIABLE;

    this.tool = modules.get(MODULE.TOOL);
    this.func = modules.get(MODULE.FUNC);
    this.array = modules.get(MODULE.ARRAY);
    this.md5 = modules.get(MODULE.MD5_SECURITY);
    this.base64 = modules.get(MODULE.BASE_64);    
    this.cache = modules.get(MODULE.CACHE);
    this.obj = modules.get(MODULE.OBJECT);
    this.version = modules.get(MODULE.VERSION).browser;
    this.jqueryEasyui = modules.get(MODULE.JQUERY_EASYUI);

    this.setGlobalCache = function (key, value) {
        this.cache.setCache(key, value);
    }

    this.getGlobalCache = function (key) {        
        return this.cache.getCache(key);
    }

    this.getGlobalCacheNoResident = function (key) {
        return this.cache.getCacheNoResident(key);
    }
}