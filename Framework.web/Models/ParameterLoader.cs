using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Framework.web
{
    public static class ParameterLoader
    {
        /// <summary>
        /// 载入AJax提交的请求参数
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static RequestData LoadAjaxPostParameters(Stream stream)
        {
            RequestData r = new RequestData();
            using (StreamReader sr = new StreamReader(stream))
            {
                var sourceData = HttpUtility.UrlDecode(sr.ReadToEnd());

                var requstDic = JSONHelper.GetModel<IDictionary<string, object>>(sourceData);

                object rdata = "";

                if (requstDic!=null && requstDic.TryGetValue("data", out rdata))
                {
                    if (rdata != null)
                    {
                        r.dataStr = rdata.ToString();
                        r.data = JSONHelper.GetModel<object>(r.dataStr);
                        r.dynamicData = JSONHelper.GetModel<dynamic>(sourceData);                       
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// 获取json响应
        /// </summary>
        /// <param name="responseData"></param>
        /// <returns></returns>
        public static string LoadResponseJSONStr(object responseData)
        {
            return JSONHelper.GetJsonString(responseData);
        }
    }
}
