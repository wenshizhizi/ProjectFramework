using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dapper
{
    public class PagingRet<T>
    {
        public int MaxCount { get; set; } = 0;

        public List<T> Result { get; set; }
    }
}
