using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Framework.ORM
{
    public class DapperDBHelper : QueryHelperBase
    {
        protected override IList<T> DoPaginationQuery<T>(SqlConnection conn, string sqlCommand, Object parameter)
        {
            if (conn != null)
            {
                
                return conn.Query<T>(sqlCommand, parameter, null, true, null, CommandType.Text).ToList<T>();
            }
            else
            {
                throw new ApplicationException("未获取到连接对象。");
            }
        }

        protected override IList<T> DoQueryList<T>(SqlConnection conn, string sqlCommand, Object parameter)
        {
            if (conn != null)
            {
                throw new ApplicationException("测试异常。");
                return conn.Query<T>(sqlCommand, parameter, null, true, null, CommandType.Text).ToList<T>();
            }
            else
            {
                throw new ApplicationException("未获取到连接对象。");
            }
        }

        protected override T DoSingleQuery<T>(SqlConnection conn, string sqlCommand, Object parameter)
        {
            if (conn != null)
            {
                return conn.Query<T>(sqlCommand, parameter, null, true, null, CommandType.Text).SingleOrDefault<T>();
            }
            else
            {
                throw new ApplicationException("未获取到连接对象。");
            }
        }
    }
}
