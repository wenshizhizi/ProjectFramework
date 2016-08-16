using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Framework.Helper;

namespace Framework.Dapper
{
    internal static class DBSqlHelper
    {
        /// <summary>
        /// 传入实体类获取插入sql
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public static string GetInsertSQL(object obj, string viewName)
        {
            //复数
            bool isList = false;
            List<Dictionary<string, object>> newList = null;
            Dictionary<string, object> newObj = null;
            StringBuilder mySQL = new StringBuilder();
            PropertyInfo[] pros = obj.GetType().GetProperties();
            //foreach (PropertyInfo pro in pros)
            //{
            //    if (pro.Name.ToLower() == "count" && obj.GetType().Name != "Dictionary`2")
            //    {
            //        isList = true;
            //        break;
            //    }
            //}

            //if (isList)
            //{
            //    newList = obj.ToObject<List<Dictionary<string, object>>>();
            //    foreach (var item in newList)
            //    {
            //        mySQL.Append(GetInsertByDictToSQL(item, viewName)).Append(";");
            //    }
            //}
            //else
            //{
            //    newObj = obj.ToObject<Dictionary<string, object>>();
            //    mySQL.Append(GetInsertByDictToSQL(newObj, viewName));
            //}
            return mySQL.ToString();
        }
    }
}
