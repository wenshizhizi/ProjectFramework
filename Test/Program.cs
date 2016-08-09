using Framework.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Entity;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryHelper qb = new DapperDBHelper();
            var list = qb.QueryList<Customer>("select * from CICUser where [Username] = @name", new { name = "yangyukun" });
        }
    }
}
