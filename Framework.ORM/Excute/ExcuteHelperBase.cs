using Framework.Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dapper
{
    public abstract class ExcuteHelperBase : ExcuteHelper
    {
        //连接字符串
        private string connectionStr = null;

        // 获取数据库连接        
        private SqlConnection GetSqlConnection()
        {
            try
            {
                if (connectionStr == null) connectionStr = web.config.WebConfig.LoadElement("connectionString");
                SqlConnection conn = new SqlConnection(connectionStr);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <param name="conn"></param>
        private void CloseConnect(SqlConnection conn)
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
            }
        }

        public override sealed int InsertSingle<T>(T t)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                if (conn == null) throw new ApplicationException("未获取到连接对象。");
                return DoInsertSingle<T>(conn,t);
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                return 0;
            }
            finally
            {
                CloseConnect(conn);
            }
        }

        public override sealed int InsertMultiple<T>(IList<T> t)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                if (conn == null) throw new ApplicationException("未获取到连接对象。");
                return DoInsertMultiple<T>(conn, t);
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                return 0;
            }
            finally
            {
                CloseConnect(conn);
            }
        }

        public override sealed int Insert(string sql, object param)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                if (conn == null) throw new ApplicationException("未获取到连接对象。");
                return DoInsert(conn, sql, param);
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                return 0;
            }
            finally
            {
                CloseConnect(conn);
            }
        }

        
        protected abstract int DoInsertSingle<T>(SqlConnection conn,T t);
        protected abstract int DoInsertMultiple<T>(SqlConnection conn, IList<T> t);
        protected abstract int DoInsert(SqlConnection conn, string sql, object param);

    }
}
