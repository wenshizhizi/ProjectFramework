/// <reference path="jquery.cookie.js" />

/**
 * 创建全局公用对象
 */
(function () {

    //全局对象
    window.common = {};
    //通过url请求的参数
    window.common.requestParam = null;
    //全局配置对象
    window.config = {
        //localstore记录的history的键名字
        historyLocalStoreName: "_HISTORY_C4_M16",
        //ajax post 超时时间
        postTimeOut: 10000,
        //ajax post 的遮罩层对象
        maskmsg: null,
        //ajax提交的上下文对象
        ajaxPostContext: null,
        //alert的弹出框divHTML
        alertDivHTMLString: "<div class='alert_box' style='position:fixed;z-index:1500;width:100%;opacity:1;height:100%;left:0;top:0px;background-color:rgba(68,68,68,0.4);transition:all 0.3s linear'><div class='content' style='width:260px;text-align:center;position:absolute;font-size:14px;left:50%;top:50%; transform:translateY(-50%) translateX(-50%);-webkit-transform:translateY(-50%) translateX(-50%);background-color:#fff;border-radius:10px'><P style='padding:20px 15px; line-height:25px; color:#333;font-size:16px'>{0}<P><div><div>"
    };

    (function initExtend() {

        /**
        * 
        * 格式化字符串
        * 
        * @method format     
        * @author [杨瑜堃]
        * @version 1.0.1
        * @param {Stringp[]} args 要格式化的替换值数组
        * @returns {String} 格式化结果 
        * 
        * @example
        * 
        * "这个就是格式化字符串的列子:{0}".format("列子")
        */
        String.prototype.format = function (args) {
            var result = this;
            if (arguments.length > 0) {
                if (arguments.length == 1 && typeof (args) == "object") {
                    for (var key in args) {
                        if (args[key] != undefined) {
                            var reg = new RegExp("({)" + key + "(})", "g");
                            result = result.replace(reg, args[key]);
                        }
                    }
                }
                else {
                    for (var i = 0; i < arguments.length; i++) {
                        if (arguments[i] != undefined) {
                            var reg = new RegExp("({)" + i + "(})", "g");
                            result = result.replace(reg, arguments[i]);
                        }
                    }
                }
            }
            return result;
        };

        /**
        * 
        * 对Date的扩展，将 Date 转化为指定格式的String
        * 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
        * 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
        * 
        * @for Date
        * @author [杨瑜堃]
        * @version 1.0.1
        * @param {String} fmt 格式化字符串
        * @returns {String} 结果 
        * 
        * @example
        *  
        * (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423
        * (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
        */
        Date.prototype.Format = function (fmt) {
            var o = {
                "M+": this.getMonth() + 1, //月份 
                "d+": this.getDate(), //日 
                "h+": this.getHours(), //小时 
                "m+": this.getMinutes(), //分 
                "s+": this.getSeconds(), //秒 
                "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
                "S": this.getMilliseconds() //毫秒 
            };
            for (var time in o) {
                if (isNaN(o[time])) {
                    return "";
                }
            }
            if (/(y+)/.test(fmt))
                fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            for (var k in o)
                if (new RegExp("(" + k + ")").test(fmt))
                    fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
            return fmt;
        };

        /* 
        *  删除数组元素:Array.removeArr(index) 
        */
        Array.prototype.removeAt = function (index) {
            if (isNaN(index) || index >= this.length) { return false; }
            this.splice(index, 1);
        }

        /* 
        *  插入数组元素:Array.insertArr(dx) 
        */
        Array.prototype.insertAt = function (index, item) {
            this.splice(index, 0, item);
        };

        /**
        * 弹出消息框
        * @param {String} msg 消息
        * @param {Function} fn 可选：显示后回调的函数
        * @param {Number} duration 显示的时间
        */
        window.alert = function AlertWindow(msg, fn, duration) {
            duration = isNaN(duration) ? 2000 : duration;

            if ($(".alert_box").length) {
                $(".alert_box .content p:first").text(msg).parents(".alert_box").css({ "opacity": "1", "width": "100%", "height": "100%" });
            }
            else {
                var win = $(window.config.alertDivHTMLString.format(msg));
                $("body").append(win);
            }
            setTimeout(function () {
                var d = 0.7;
                $(".alert_box")[0].style.webkitTransition = '-webkit-transform ' + d + 's ease-in, opacity ' + d + 's ease-in';
                $(".alert_box")[0].style.opacity = '0';
                if (fn) fn();
                setTimeout(function () { $(".alert_box").remove(); }, d * 1000);
            }, 2000);
        };
    })();

    //提供浏览历史的相关方法
    window.common.history = new function () {
        //是否支持LocalStorage
        var isSupportLocalStorage = window.localStorage != undefined && window.localStorage != null;

        //指定系统键的返回地址（主要针对的是安卓的返回键）
        var backUrl = null;

        /**
         * 获取上一个浏览记录
         * @returns {String} 浏览记录 
         */
        function getPrev() {
            if (isSupportLocalStorage) {
                var _history = getLocalStorage();
                if (_history.length > 1) {
                    return _history[_history.length - 2];
                } else {
                    return null;
                }
            }
        }

        /**
         * 获取第一个浏览记录
         * @returns {String} 浏览记录 
         */
        function getFirst() {
            if (isSupportLocalStorage) {
                var _history = getLocalStorage();
                if (_history.length > 0) {
                    return _history[0];
                } else {
                    return null;
                }
            }
        }

        /**
         * 获取最后一次访问记录
         * @returns {type} 
         */
        function getLast() {
            if (isSupportLocalStorage) {
                var _history = getLocalStorage();
                if (_history.length > 0) {
                    return _history[_history.length - 1];
                } else {
                    return null;
                }
            }
        }

        /**
         * 移除最后一次浏览记录
         */
        function removeLast() {
            if (isSupportLocalStorage) {
                var _history = getLocalStorage();
                if (_history.length > 0) {
                    _history.pop();
                    resetLocalStorage(_history);
                }
            }
        }

        /**
         * 更新历史记录的值
         * @param {Array<String>} obj
         */
        function resetLocalStorage(obj) {
            if (isSupportLocalStorage) {
                window.localStorage.setItem(window.config.historyLocalStoreName, JSON.stringify(obj));
            }
        }

        /**
         * 获取历史记录的值
         * @returns {Array<String>} 
         */
        function getLocalStorage() {
            if (isSupportLocalStorage) {
                var items = window.localStorage.getItem(window.config.historyLocalStoreName);
                if (items) {
                    return JSON.parse(items);
                } else {
                    return new Array();
                }
            }
        }

        /**
         * 返回上一次浏览记录
         */
        function back() {
            if (isSupportLocalStorage) {
                var url/*上次浏览*/ = getPrev();
                if (url != null) {
                    removeLast();//移除最后浏览（当前页）                    
                    window.location.href = url;
                }
            }
        }

        /**
         * 记录一条浏览信息
         * @param {String} url 网址
         */
        function pushHistory(url) {
            if (isSupportLocalStorage) {
                var _history = getLocalStorage();
                if (_history.length > 0) {
                    for (var i = _history.length - 1; i >= 0; i--) {
                        if (_history[i] === url) {
                            _history.removeAt(i);
                            i--;
                        }
                    }
                    _history.push(url);
                } else {
                    _history.push(url);
                }
                resetLocalStorage(_history);
            } else {
                return alert("浏览器版本太老，请升级浏览器");
            }
        }

        /**
         * 设置物理返回键（针对安卓的返回键）的地址
         * @method setBackURL    
         * @author [杨瑜堃]
         * @version 1.0.1
         * @param {String} url
         */
        function setBackURL(url) {
            backUrl = url;
            if (history && history.pushState) {
                window.history.pushState(null, null, null);
                window.onpopstate = function doState(e) {
                    //移除当前路径
                    removeLast();
                    //跳转到指定路径
                    window.location.href = backUrl;
                };
            } else {
                return alert("浏览器版本太老，请升级浏览器");
            }
        }

        return {
            back: back,
            pushHistory: pushHistory,
            setBackURL: setBackURL
        };
    };

    $(function onDocumentReady() {
        window.common.history.pushHistory(window.location.pathname);
    });

    //post内部使用的一些方法
    window.$_c4 = {
        /**
        * 
        * 对参数进行URL编码
        * 
        * @method encodeParam    
        * @author [杨瑜堃]
        * @version 1.0.1
        * @param {json} jsonObj 要编码的对象
        * @returns {string} 编码结果
        */
        encodeParam: function (jsonObj) {
            if (!jsonObj) return jsonObj;
            if (jsonObj instanceof String) {
                return encodeURIComponent(jsonObj);
            } else {
                return encodeURIComponent(JSON.stringify(jsonObj));
            }
        },

        /**
         * 
         * 显示遮罩层
         * 
         * @method show    
         * @author [杨瑜堃]
         * @version 1.0.1
         * @param [String] msg 可选：要显示的遮罩层文本
         */
        show: function (msg) {
            var h = $(document).height();
            window.config.maskmsg = $('<div style="height:100%;width:100%;position:fixed;z-index:99999;background: rgba(255,255,255,0.8);left:0px;top:0px;">' +
                            '<div style="position:absolute;overflow:hidden;left:50%;top:50%;margin-left:-34px;margin-top:-34px;height:68px;width:68px;text-align:center;">' +
                                '<span class="circles-loader"></span>' +
                            '</div>' +
                        '</div>');
            if (msg) {
                window.config.maskmsg.find("div").text(msg);
            }
            window.config.maskmsg.appendTo("body");
            setTimeout(
            (function (maskmsg) {
                return function () {
                    maskmsg.remove();
                };
            })(window.config.maskmsg), window.config.postTimeOut);
        },

        /**
         * 
         * 隐藏遮罩层
         * 
         * @method hide        
         * @author [杨瑜堃]
         * @version 1.0.1
         */
        hide: function () {
            if (window.config.maskmsg !== null) {
                window.config.maskmsg.remove();
                window.config.maskmsg = null;
            }
        }
    };

    /**
     * 序列化容器内的带name属性的输入框的值为json object
     * @method serializeObject
     * @for ObjectDomain
     * @author [王其]
     * @version 1.0.1
     * @returns {Object}  
     */
    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name] !== undefined) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

    /**
     * ajax post 
     * @param {String} url 提交的地址
     * @param {Json} data 提交的数据
     * @param {Function} onSuccess 成功时的回调函数，有个参数是回调的data
     * @param {Function} unSucess 失败时的回调函数，有个参数是回调的data
     * @param {Boolean} modal 是否启用遮罩层 默认开启
     * @param {Boolean} async 是否是异步
     * @param {Function} onError 错误时的回调函数
     * @param {Function} onComplete 完成时的回调函数
     * @param {String} dataType 数据类型
     */
    window.common.post = function post(url, data, onSuccess, unSucess, modal, async, onError, onComplete, dataType) {

        //判断是否提交期间开启遮罩层
        modal = (modal == false ? false : true);

        //如果要开启遮罩层就显示遮罩层（遮罩层的样式在项目根目录下的Conten/home.css中）
        if (modal) window.$_c4.show();

        //封装jsondata，对参数进行url编码
        var jsonData = window.$_c4.encodeParam({ data: data });

        var ajaxHandler = $.ajax.call(window.config.ajaxPostContext, {
            type: "post",
            url: url,
            cache: false,
            contentType: "application/x-www-form-urlencoded",
            dataType: (dataType ? dataType : "text"),
            data: jsonData,
            async: (async == false ? async : true),
            success: function (json) {
                try {
                    //调用成功，服务端返回结果

                    //如果显示了遮罩层就去掉
                    if (modal) {
                        window.$_c4.hide();
                    }

                    //由于返回的是text，这里解析成对象
                    var result = JSON.parse(json || null);

                    //将Data解析为对象
                    result.Data = JSON.parse(result.Data || null);

                    //返回结果成功就调用成功的回调函数
                    if (result.Succeeded) {
                        onSuccess(result);
                    }

                    //返回失败且要自己处理错误就调用服务端通知失败的回调函数
                    if (!result.Succeeded && unSucess) {
                        unSucess(result);
                    }
                } catch (e) {
                    alert(e.message);
                }
            },
            error: onError ? onError : function () {
                ajaxHandler.abort();
                if (modal) {
                    window.$_c4.hide();
                }
            },
            //请求完成后最终执行参数
            complete: function (XMLHttpRequest, status) {
                if (status === 'timeout') {
                    //超时,status还有success,error等值的情况
                    alert("访问超时");
                    ajaxHandler.abort();
                    if (modal) {
                        window.$_c4.hide();
                    }
                }
            }
        });
    };

    /**
     * 带确认取消按钮的确认框
     * @param {String} msg 提示的信息
     * @param {Object} okOptopn 确认按钮配置，格式如下：{"text":"确定按钮",fn:function(){ //这里是按了确定后触发的事件 }}
     * @param {Object} canclOption 取消按钮配置，格式如下：{"text":"取消按钮",fn:function(){ //这里是按了取消后触发的事件 }}
     * @param {Function} callback 可选：按了确定后，调了确定方法后的回调事件
     */
    $.confirm = function (msg, okOptopn, canclOption, callback) {
        //创建背景DIV
        var divBackground = document.createElement("div");

        //设置背景DIV样式
        divBackground.style.cssText = "position:fixed;top: 0;left:0;width: 100%;height: 100%;background: rgba(0,0,0,0.5);z-index:9999999999";

        //创建内容DIV
        var divContent = document.createElement("div");

        //设置DIV样式
        divContent.style.cssText = "width: 72%;background: #ffffff;border-radius: 8px;margin:70% auto;position: relative;text-align: center;overflow:hidden;font-size:14px;";

        //创建消息SPAN
        var span = document.createElement("span");

        //设置消息提示内容
        span.innerHTML = msg;

        //设置消息span样式
        span.style.cssText = "margin: 20px;display:block;";

        //创建下方两个按钮的ul容器
        var ul = document.createElement("ul");

        //设置ulstyle
        ul.style.cssText = "margin-top:10px;border-top: 1px solid #dcdcdc;";

        //#region 取消按钮（默认）
        var li1 = document.createElement("li");
        //设置按钮样式（默认）
        li1.style.cssText = "text-align: center;line-height: 40px;float:left;width:50%;border-right: 1px solid gainsboro;margin-left:-1px;font-size:12px;color:red;";
        li1.innerHTML = "取消";
        //检查是否自定义取消按钮文本
        if (canclOption && canclOption.text) {
            li1.innerHTML = canclOption.text;
        }
        //绑定取消按钮事件
        li1.onclick = function () {
            if (canclOption.fn) canclOption.fn();
            document.body.removeChild(divBackground);
        };
        //#endregion

        //#region 确认按钮（默认）
        var li2 = document.createElement("li");
        //设置按钮样式（默认）
        li2.style.cssText = "text-align: center;line-height: 40px;float:left;width:50%;font-size:12px;color:red;";
        li2.innerHTML = "确定";
        //检查是否自定义确认按钮文本
        if (okOptopn && okOptopn.text) {
            li2.innerHTML = okOptopn.text;
        }
        //绑定确认按钮事件
        li2.onclick = function () {
            if (okOptopn.fn) okOptopn.fn();
            if (callback) callback();
            document.body.removeChild(divBackground);
        };
        //#endregion

        ul.appendChild(li1);
        ul.appendChild(li2);
        divContent.appendChild(span);
        divContent.appendChild(ul);
        divBackground.appendChild(divContent);
        document.body.appendChild(divBackground);
    };

}());

