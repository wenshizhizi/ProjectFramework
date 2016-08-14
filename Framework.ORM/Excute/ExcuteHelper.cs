using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dapper
{
    public abstract class ExcuteHelper
    {
        /// <summary>
        /// 插入单条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual int InsertSingle<T>(T t)
        {
            return 0;
        }

        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int InsertMultiple<T>(IList<T> t)
        {
            return 0;
        }

        /// <summary>
        /// 插入（sql）
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual int Insert(String sql,object param)
        {
            return 0;
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual int ExcuteTransaction(string sql)
        {
            return 0;
        }

        /// <summary>
        /// 更新单条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int UpdateSingle<T>(T t)
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public virtual int Update(String sql, object param)
        {
            return 0;
        }

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual int UpdateMultiple<T>(IList<T> t)
        {
            return 0;
        }
    }
}
