using Newtonsoft.Json;
using System.Collections.Generic;

namespace Framework.Helper
{
    public class JSONHelper
    {

        /// <summary>
        /// 从json字符串获取泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sJson"></param>
        /// <returns></returns>
        public T GetModel<T>(string sJson)
        {
            return JsonConvert.DeserializeObject<T>(sJson);
        }
    }
}
