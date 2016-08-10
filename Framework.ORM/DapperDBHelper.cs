using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Framework.Dapper
{
    public class DapperDBHelper : QueryHelperBase
    {
        protected override IList<T> DoPaginationQuery<T>(SqlConnection conn, string sqlCommand, PageInfo pageInfo, Object parameter)
        {
            if (conn != null)
            {

                string lcSQL = string.Format(@"DECLARE @mc INT SELECT @mc = COUNT(1) FROM ({0}) AS aaaa3 ", sqlCommand);
                int startPage = pageInfo.PageSize * (pageInfo.PageIndex - 1) + 1;
                int endPage = startPage + pageInfo.PageSize - 1;
                lcSQL += string.Format(@"SELECT *,@mc MaxCount  FROM (SELECT ROW_NUMBER() OVER(ORDER BY {3}) AS ROWNUM,* FROM ({0}) AS aaaa1) AS query WHERE ROWNUM BETWEEN {1} AND {2} ",
                    new object[] { sqlCommand, startPage, endPage, pageInfo.OrderBy == string.Empty ? "(SELECT 0)" : (string.Format(" {0} {1}", pageInfo.OrderBy, pageInfo.orderType == OrderType.ASC ? "ASC" : "DESC")) });


                var temp = conn.Query<T, PagingRet<T>, PagingRet<T>>(lcSQL, (p, t) =>
            {
                t.Result = p;
                return t;
            }, parameter, null, true, null, null, CommandType.Text).FirstOrDefault(); // lcSQL, parameter, null, true, null, CommandType.Text).FirstOrDefault();

                return null;

                //var temp = conn.Query<PagingRet<T>>(lcSQL, parameter, null, true, null, CommandType.Text);
                //return null;

                //return conn.Query<IList<T>, T, PagingRet<T>>(lcSQL, (p, t) =>
                //{                 
                //    p.Result.Add(t);
                //    return p;
                //}, parameter,null, true, null, null, CommandType.Text).FirstOrDefault(); // lcSQL, parameter, null, true, null, CommandType.Text).FirstOrDefault();
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
