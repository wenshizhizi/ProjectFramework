using Newtonsoft.Json;
using System.Collections.Generic;

namespace Framework.Helper
{
    public class JSONHelper
    {
        /// <summary>
        /// 从json字符串获取泛型对象
        /// </summary>
        /// <typeparam name="T">要生成的对象类型</typeparam>
        /// <param name="sJson">JSON字符串</param>
        /// <returns>从JSON生成的对象</returns>
        public static T GetModel<T>(string sJson)
        {
            return JsonConvert.DeserializeObject<T>(sJson);
        }

        /// <summary>
        /// 从对象生成json字符串
        /// </summary>
        /// <typeparam name="T">要生成的对象类型</typeparam>
        /// <param name="t">要生成的对象</param>
        /// <returns>生成结果</returns>
        public static string GetJsonString<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}
