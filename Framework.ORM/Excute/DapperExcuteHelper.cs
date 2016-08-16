using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dapper.Excute
{
    public class DapperExcuteHelper : ExcuteHelperBase
    {
        protected override int DoInsert(SqlConnection conn, string sql, object param)
        {
            throw new NotImplementedException();
        }

        protected override int DoInsertMultiple<T>(SqlConnection conn, IList<T> t)
        {
            throw new NotImplementedException();
        }

        protected override int DoInsertSingle<T>(SqlConnection conn, T t)
        {
            throw new NotImplementedException();
        }
    }
}
