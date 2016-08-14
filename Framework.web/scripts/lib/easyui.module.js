/*!
 * Yangyukun Script Library
 * version: 1.0.1
 * build: Sun Aug 14 2016 15:04:36 GMT+0800 (中国标准时间)
 * Released under MIT license
 * 
 * Include [func.module.js,tool.module.js] 
 */

modules.define("eui", ["func", "tool"], function (func, tool) {

    $($.extend($.fn.validatebox.defaults.rules, {
        //最小数字
        minNumber: {
            validator: function (value, param) {
                return parseFloat(value) > parseFloat(param[0]);
            },
            message: '该字段不得小于等于{0}'
        },
        //验证是否是数字
        isNumber: {
            validator: function (value, param) {
                return !isNaN(value);
            },
            message: '请输入正确数字'
        },
        //验证整数是否小于设置的值
        maxInt: {
            validator: function (value, param) {
                return parseInt(value) <= parseInt(param[0]);
            },
            message: '该字段值不得大于{0}'
        },
        //验证整数是否大于设置的值
        minInt: {
            validator: function (value, param) {
                return parseInt(value) >= parseInt(param[0]);
            },
            message: '该字段值不得小于{0}'
        },
        //验证Float是否小于设置的值
        maxFloat: {
            validator: function (value, param) {
                return parseFloat(value) <= parseFloat(param[0]);
            },
            message: '该字段值不得大于{0}'
        },
        //验证最小字符
        minLength: {
            validator: function (value, param) {
                return $.trim(value).length >= param[0];
            },
            message: '请至少输入{0}个字符'
        },
        //验证最大字符
        maxLength: {
            validator: function (value, param) {
                return $.trim(value).length < param[0];
            },
            message: '该字段只能输入{0}个字符'
        },
        //验证字符只能在某个范围内，param[0]是最小值，param[1]是最大值
        chartLengthBetween: {
            validator: function (value, param) {
                return $.trim(value).length <= param[1] && $.trim(value).length >= param[0];
            },
            message: "{2}只能是{0}-{1}位的字符"
        },
        //是否是电话号码
        isPhoneNum: {
            validator: function (value, param) {
                var patrn = /^((13[0-9]|14[0-9]|15[0-9]|17[0-9]|18[0-9])\d{8})*$/;
                if (patrn.exec(value))
                    return true;
                var patrn = /^(\d{3}-\d{8}|\d{4}-\d{7})*$/;
                if (patrn.exec(value))
                    return true;
                return false;
            },
            message: "该字段只能是11位手机号"
        },
        //是否是html
        isHtmlValidate: {
            validator: function (value, param) {
                //if (!/<[^>]+>/g.test(value)) {
                //    if (value.length != 0 && value.replace(/(^\s*)|(\s*$)/g, "").length == 0) {
                //        return false;
                //    }
                //    return true;
                //}
                //var re = new RegExp("<[^>]+>", "ig");
                //while (r = re.exec(value)) {
                //    var str = r[0].replace(/\<|\>|\"|\'|\&/g, "");
                //    if (/^[A-Za-z/]+$/g.test(str)) {
                //        return false;
                //    }
                //}
                //var re= new RegExp('^<([^>]+)[^>]*>(.*?<\/\\1>)?$');
                return $("<span/>").html(value).text() == value;
                //return /<[^>]+>/g.test(value);
            },
            message: "禁止输入非法的html字符"
        },
        //是否是正确货号
        isGoodsNo: {
            validator: function (value, param) {
                if (!/^[0-9]*$/.test(value))
                    return false;
                else
                    return true;
            },
            message: "请输入正确的货号"
        },
        //验证字符是否是指定长度
        chartLengthEquire: {
            validator: function (value, param) {
                return value.length === parseInt(param[0]);
            },
            message: '请输入长度为{0}的{1}'
        },
        notEquireCharter: {
            validator: function (value, param) {
                return $.trim(value) !== param[0];
            },
            message: '{0}'
        }
    }));

    function alertMsg(msg) {
        $.messager.alert("提示",msg,"warning");
    }

    function alertErr(err) {
        $.messager.alert("错误", msg, "error");
    }

    function alertInfo(info){
        $.messager.alert("信息", msg, "info");
    }

    return {
        alertMsg: alertMsg,
        alertErr: alertErr,
        alertInfo: alertInfo
    };
});