using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dapper
{
    public interface IQueryHelper
    {
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <typeparam name="T">映射类型</typeparam>
        /// <param name="sqlCommand">sql</param>
        /// <param name="parameter">参数</param>
        /// <returns>查询结果</returns>
        T SingleQuery<T>(string sqlCommand, Object parameter) where T : new();


        /// <summary>
        /// 查询多条数据
        /// </summary>
        /// <typeparam name="T">映射类型</typeparam>
        /// <param name="sqlCommand">sql</param>
        /// <param name="parameter">参数</param>
        /// <returns>查询结果</returns>
        IList<T> QueryList<T>(string sqlCommand, Object parameter) where T : new();


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">映射类型</typeparam>
        /// <param name="sqlCommand">sql</param>
        /// <param name="parameter">参数</param>
        /// <returns>查询结果</returns>
        PagingRet<T> PaginationQuery<T>(string sqlCommand, PageInfo pageInfo, Object parameter) where T : new();

    }
}
