using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Framework.Log;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ORM
{
    public abstract class QueryHelperBase : QueryHelper
    {
        //连接字符串
        private static readonly string connectionStr = web.config.WebConfig.LoadElement("connectionString");

        // 获取数据库连接        
        private SqlConnection GetSqlConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionStr);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(new ApplicationException("获取数据库链接时失败。", ex));
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
                Logs.GetLog().WriteErrorLog(new ApplicationException("关闭数据库链接时失败。", ex));
            }
        }

        /// <summary>
        /// 这部分代码由于实现了对异常的处理，并且开放给外部的接口
        /// 就是通过调用该部分，因此该方法不允许被重写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override sealed T SingleQuery<T>(string sqlCommand, Object parameter)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                return DoSingleQuery<T>(conn, sqlCommand, parameter);
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                return default(T);
            }
            finally
            {
                CloseConnect(conn);
            }
        }

        /// <summary>
        /// 这部分代码由于实现了对异常的处理，并且开放给外部的接口
        /// 就是通过调用该部分，因此该方法不允许被重写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override sealed IList<T> QueryList<T>(string sqlCommand, Object parameter)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                return DoQueryList<T>(conn, sqlCommand, parameter);
            }
            catch (Exception ex)
            {
                Logs.GetLog().WriteErrorLog(ex);
                return null;
            }
            finally
            {
                CloseConnect(conn);
            }
        }

        /// <summary>
        /// 这部分代码由于实现了对异常的处理，并且开放给外部的接口
        /// 就是通过调用该部分，因此该方法不允许被重写
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlCommand"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override sealed IList<T> PaginationQuery<T>(string sqlCommand, Object parameter)
        {
            SqlConnection conn = null;
            try
            {
                conn = GetSqlConnection();
                return DoPaginationQuery<T>(conn, sqlCommand, parameter);
            }
            catch (Exception ex)
            {

                Logs.GetLog().WriteErrorLog(ex);
                return null;
            }
            finally
            {
                CloseConnect(conn);
            }
        }

        /// <summary>
        /// 子类真正应该实现的查询单条数据的方法
        /// </summary>
        /// <typeparam name="T">映射类型</typeparam>
        /// <param name="conn">数据库链接对象</param>
        /// <param name="sqlCommand">sql</param>
        /// <param name="parameter">参数</param>
        /// <returns>查询结果</returns>
        protected abstract T DoSingleQuery<T>(SqlConnection conn, string sqlCommand, Object parameter);

        /// <summary>
        /// 子类真正应该实现的查询多条数据方法
        /// </summary>
        /// <typeparam name="T">映射类型</typeparam>
        /// <param name="conn">数据库链接对象</param>
        /// <param name="sqlCommand">sql</param>
        /// <param name="parameter">参数</param>
        /// <returns>查询结果</returns>
        protected abstract IList<T> DoQueryList<T>(SqlConnection conn, string sqlCommand, Object parameter);

        /// <summary>
        /// 子类真正应该实现的分页查询数据方法
        /// </summary>
        /// <typeparam name="T">映射类型</typeparam>
        /// <param name="conn">数据库链接对象</param>
        /// <param name="sqlCommand">sql</param>
        /// <param name="parameter">参数</param>
        /// <returns>查询结果</returns>
        protected abstract IList<T> DoPaginationQuery<T>(SqlConnection conn, string sqlCommand, Object parameter);
    }
}
