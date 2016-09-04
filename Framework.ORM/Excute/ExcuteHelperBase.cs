using Framework.SystemLog;
using System;
using System.Collections.Generic;
using System.Data;
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
                return DoInsertSingle<T>(conn, t);
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
            IDbTransaction tran = null;
            try
            {
                conn = GetSqlConnection();
                if (conn == null) throw new ApplicationException("未获取到连接对象。");
                tran = conn.BeginTransaction();
                return DoInsertMultiple<T>(conn, tran, t);
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                if (tran != null)
                {
                    tran.Rollback();
                }
                return 0;
            }
            finally
            {
                if (tran != null) tran.Dispose();
                CloseConnect(conn);
            }
        }

        public sealed override int ExcuteTransaction(string sql)
        {
            SqlConnection conn = null;
            IDbTransaction tran = null;
            try
            {
                conn = GetSqlConnection();
                if (conn == null) throw new ApplicationException("未获取到连接对象。");
                tran = conn.BeginTransaction();
                return DoExcuteTransaction(conn,tran,sql);
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                if (tran != null)
                {
                    tran.Rollback();
                }
                return 0;
            }
            finally
            {
                if (tran != null) tran.Dispose();
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

        public override int Update(string sql, object param)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                if (conn == null) throw new ApplicationException("未获取到连接对象。");
                return DoUpdate(conn, sql, param);
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

        public override int UpdateMultiple<T>(IList<T> t, string where)
        {
            SqlConnection conn = null;
            IDbTransaction tran = null;
            try
            {
                conn = GetSqlConnection();
                if (conn == null) throw new ApplicationException("未获取到连接对象。");
                tran = conn.BeginTransaction();
                return DoUpdateMultiple<T>(conn, tran, t, where);
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                if (tran != null)
                {
                    tran.Rollback();
                }
                return 0;
            }
            finally
            {
                if (tran != null) tran.Dispose();
                CloseConnect(conn);
            }
        }

        public override int UpdateSingle<T>(T t, string where)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                if (conn == null) throw new ApplicationException("未获取到连接对象。");
                return DoUpdateSingle<T>(conn, t, where);
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
        
        protected abstract int DoInsertSingle<T>(SqlConnection conn, T t);
        protected abstract int DoInsertMultiple<T>(SqlConnection conn, IDbTransaction tran, IList<T> t);
        protected abstract int DoInsert(SqlConnection conn, string sql, object param);

        protected abstract int DoUpdateSingle<T>(SqlConnection conn, T t, string where);
        protected abstract int DoUpdateMultiple<T>(SqlConnection conn, IDbTransaction tran, IList<T> t, string where);
        protected abstract int DoUpdate(SqlConnection conn, string sql, object param);
        protected abstract int DoExcuteTransaction(SqlConnection conn, IDbTransaction tran, string sql);
    }
}
