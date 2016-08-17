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
            return conn.Execute(sql, param, null, null, System.Data.CommandType.Text);
        }

        protected override int DoInsertMultiple<T>(SqlConnection conn, IDbTransaction tran, IList<T> t)
        {
            StringBuilder sb = new StringBuilder();
            Parallel.ForEach(t, item =>
            {
                sb.Append(DBSqlHelper.GetInsertSQL(item));
            }); 
            return conn.Execute(sb.ToString(), null, tran, null, CommandType.Text);
        }

        protected override int DoInsertSingle<T>(SqlConnection conn, T t)
        {
            string sql = DBSqlHelper.GetInsertSQL<T>(t);
            return conn.Execute(sql);
        }

        protected override int DoUpdate(SqlConnection conn, string sql, object param)
        {
            return conn.Execute(sql);
        }

        protected override int DoUpdateMultiple<T>(SqlConnection conn, IDbTransaction tran, IList<T> t, string where)
        {
            //StringBuilder sb = new StringBuilder();
            //Parallel.ForEach(t, item => {
            //    sb.Append(DBSqlHelper.GetUpdateSQL<T>(item));
            //});
            //return conn.Execute(sb.ToString(), null, tran, null, CommandType.Text);

            return 0;
        }

        protected override int DoUpdateSingle<T>(SqlConnection conn, T t, string where)
        {
            string sql = DBSqlHelper.GetUpdateSQL<T>(t, where);
            return conn.Execute(sql);
        }
    }
}
