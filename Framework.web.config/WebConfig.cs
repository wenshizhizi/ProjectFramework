using System;
using System.IO;
using System.Collections.Generic;
using Framework.Helper;

namespace Framework.web.config
{
    public class WebConfig
    {

        private static IDictionary<string, string> configJson = new Dictionary<string, string>();

        //初始化配置
        static WebConfig()
        {
            using (TextReader tr = new StreamReader("frame.config.json"))
            {
                string configStr = tr.ReadToEnd();
                configJson = JSONHelper.GetModel<IDictionary<string, string>>(configStr);
            }
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>value</returns>
        public static String LoadElement(string key)
        {
            string ret = string.Empty;
            configJson.TryGetValue(key, out ret);
            return ret;
        }        
    }
}
