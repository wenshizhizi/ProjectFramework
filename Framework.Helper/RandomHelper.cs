using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Helper
{
    public class RandomHelper
    {
        private static Random random = new Random();

        /// <summary>
        /// 获取指定位数的数字随机数字符串
        /// </summary>
        /// <param name="s">最小数</param>
        /// <param name="e">最大数</param>
        /// <param name="bit">位数</param>
        /// <returns>生成结果</returns>
        public static string GetRandomIntString(int s = 0, int e = int.MaxValue, int bit = 4)
        {
            var ret = random.Next(s, e);
            var retStr = ret.ToString();
            if(retStr.Length > bit)
            {
                return retStr.Substring(retStr.Length - bit, bit);
            }
            else
            {
                return ret.ToString().PadLeft(bit, '0');
            }            
        }
    }
}
