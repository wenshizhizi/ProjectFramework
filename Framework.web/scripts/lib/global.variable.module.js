/*!
 * Yangyukun Script Library 该模块专门用来存储一些全局的变量
 * version: 1.0.1
 * build: Wed Sep 14 2016 21:06:39 GMT+0800 (中国标准时间)
 * Released under MIT license
 * 
 */

modules.define("cache", ["func"], function CacheDomain(func) {

    var global = {
        menus: {}
    };

    /**
     * 清除指定的key对应的全局变量
     * @param {String} key 键
     */
    function cleanVariable(key) {
        if (global[key]) {
            delete global[key];
        }
    }

    /**
     * 清除所有的全局变量
     */
    function cleanGlobal() {
        for (var v in global) {
            delete global[v];
        }
    }

    /**
     * 获取临时变量
     * @param {String} key 键
     * @returns {Object} 值，如果没有对应的key，则返回null
     */
    function getCache(key) {
        var ret = global[key];
        return ret ? ret : null;
    }

    /**
     * 获取临时变量并不再保留
     * @param {type} key 键
     * @returns {type} 值，如果没有对应的key，则返回null
     */
    function getCacheNoResident(key) {
        var ret = global[key];
        if (ret) {
            delete global[key];
        }
        return ret ? ret : null;
    }

    /**
     * 设置临时变量
     * @param {String} key 键
     * @param {Object} value 值
     */
    function setCache(key, value) {
        global[key] = value;
    }

    /**
     * 设置菜单操作域
     * @param {type} domainInfo 菜单操作域domainInfo     
     */
    function setMenuDomain(domain) {        
        global.menus[domain.id] = domain;
    }

    /**
     * 清理菜单操作域
     * @param {type} title 菜单标题
     */
    function cleanMenuDomain(title) {        
        for (var x in global.menus) {
            if (global.menus[x].title === title) {
                delete global[x];
                break;
            }
        }
    }

    /**
     * 清除指定id菜单域对象
     * @param {type} id
     */
    function cleanMenuDomainById(id) {
        if (global.menus[id])
            delete global.menus[id];
    }

    /**
     * 获取菜单操作域
     * @param {type} title 菜单标题（中文）
     * @returns {type} 操作域
     */
    function getMenuDomain(title) {
        var domain = null;
        for (var x in global.menus) {
            if (global.menus[x].title === title) {
                domain = global.menus[x].domain;
                break;
            }
        }
        return domain;
    }

    return {
        cleanGlobal: cleanGlobal,
        getCache: getCache,
        getCacheNoResident: getCacheNoResident,
        setCache: setCache,
        cleanCache: cleanVariable,
        global: global,
        setMenuDomain: setMenuDomain,
        cleanMenuDomain: cleanMenuDomain,
        getMenuDomain: getMenuDomain,
        cleanMenuDomainById: cleanMenuDomainById
    };
});