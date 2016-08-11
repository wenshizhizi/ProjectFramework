using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dapper
{
    public class PagingRet<T> where T : new()
    {
        public int MaxCount { get; set; } = 0;

        public T Result { get; set; } = new T();
    }
}
