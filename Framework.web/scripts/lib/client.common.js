/**
 * 创建全局公用对象
 */
$(function () {

    //全局对象
    window.common = {};

    /**
     * ajax post 
     * @param {String} url 提交的地址
     * @param {Json} data 提交的数据
     * @param {Function} onSuccess 成功时的回调函数，有个参数是回调的data
     * @param {Function} unSucess 失败时的回调函数，有个参数是回调的data
     * @param {Boolean} modal 是否启用遮罩层
     * @param {Boolean} async 是否是异步
     * @param {Function} onError 错误时的回调函数
     * @param {Function} onComplete 完成时的回调函数
     * @param {String} dataType 数据类型
     */
    window.common.post = function post(url, data, onSuccess, unSucess, modal, async, onError, onComplete, dataType) {

        modal = (modal == false ? false : true);
        if (modal) {
            if (tool) {
                tool.show();
            }
        }

        var jsonData = {
            data: data
        };

        var ajaxHandler = $.ajax({
            type: "post",
            url: url,
            cache: false,
            contentType: "application/x-www-form-urlencoded",
            dataType: (dataType ? dataType : "text"),
            data: zip(jsonData),
            async: (async == false ? async : true),
            success: function (json) {
                if (modal) {
                    if (tool) {
                        tool.hide();
                    }
                }

                var result = JSON.parse(json || null);
                try {
                    result.Data = JSON.parse(result.Data || null);
                } catch (e) {
                }

                if (result.Succeeded) {
                    onSuccess(result);
                }

                if (!result.Succeeded && unSucess) {
                    unSucess(result);
                }
            },
            error: onError ? onError : function () {
                ajaxHandler.abort();
                if (tool) {
                    tool.hide();
                }
            },
            //请求完成后最终执行参数
            complete: function (XMLHttpRequest, status) {
                if (status === 'timeout') {
                    //超时,status还有success,error等值的情况
                    alert("访问超时");
                    ajaxHandler.abort();
                    if (tool) {
                        tool.hide();
                    }
                }
            }
        });
    }

    /**
     * 
     * 对参数进行URL编码
     * 
     * @method zip    
     * @author [杨瑜堃]
     * @version 1.0.1
     * @param {json} jsonObj 要编码的对象
     * @returns {string} 编码结果
     */
    function zip(jsonObj) {
        if (!jsonObj) return jsonObj;
        if (jsonObj instanceof String) {
            return encodeURIComponent(jsonObj);
        } else {
            return encodeURIComponent(JSON.stringify(jsonObj));
        }
    }

    var maskmsg = null;

    /**
     * 
     * 显示遮罩层
     * 
     * @method show    
     * @author [杨瑜堃]
     * @version 1.0.1
     * @param [String] msg 可选：要显示的遮罩层文本
     */
    function show(msg) {
        var h = $(document).height();
        maskmsg = $('<div style="height:100%;width:100%;position:fixed;z-index:99999;background: rgba(255,255,255,0.8);left:0px;top:0px;">' +
                        '<div style="position:absolute;overflow:hidden;left:50%;top:50%;margin-left:-34px;margin-top:-34px;height:68px;width:68px;text-align:center;">' +
                            '<span class="circles-loader"></span>' +
                        '</div>' +
                    '</div>');
        if (msg) {
            maskmsg.find("div").text(msg);
        }
        maskmsg.appendTo("body");
        setTimeout(
        (function (maskmsg) {
            return function () {
                maskmsg.remove();
            };
        })(maskmsg), 10000);
    }

    /**
     * 
     * 隐藏遮罩层
     * 
     * @method hide
     * @for Maskin
     * @author [杨瑜堃]
     * @version 1.0.1
     */
    function hide() {
        if (maskmsg !== null) {
            maskmsg.remove();
            maskmsg = null;
        }
    }
});