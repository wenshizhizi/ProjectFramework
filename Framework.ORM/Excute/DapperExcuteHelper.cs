using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Framework.Dapper
{
    public class DapperExcuteHelper : ExcuteHelperBase
    {
        protected override int DoInsert(SqlConnection conn, string sql, object param)
        {
            return conn.ExecuteScalar<int>(sql, param, null, null, System.Data.CommandType.Text);
        }

        protected override int DoInsertMultiple<T>(SqlConnection conn, IDbTransaction tran, IList<T> t)
        {
            return 0;
            //return conn.ExecuteScalar<int>()
        }

        protected override int DoInsertSingle<T>(SqlConnection conn, T t)
        {
            string sql = DBSqlHelper.GetInsertSQL<T>(t);
            return conn.ExecuteScalar<int>(sql);
        }


    }
}
