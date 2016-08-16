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
        public static string GetInsertSQL<T>(T t)
        {
            StringBuilder mySQL = new StringBuilder();
            List<string> fs = new List<string>();
            List<string> vs = new List<string>();
            mySQL.Append("INSERT INTO ");
            PropertyInfo[] pros = t.GetType().GetProperties();
            var tbName = t.GetType().GetCustomAttribute<Framework.DTO.TableInfo>();
                        
            mySQL.Append(string.Format("[{0}]", tbName.TableName));

            foreach (var pro in pros)
            {
                var field = pro.GetCustomAttribute<Framework.DTO.FieldInfo>();
                var value = pro.GetValue(t).ToString();
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    fs.Add(string.Format("[{0}]", field.FiledName));
                    var pName = pro.PropertyType.FullName.ToLower();

                    if (pName.IndexOf("guid") >= 0 || pName.IndexOf("datetime") >= 0 || pName.IndexOf("string") >= 0)
                    {
                        vs.Add(string.Format("'{0}'", value));
                    }
                    else if (pName.IndexOf("int32") >= 0)
                    {
                        vs.Add(string.Format("{0}", value));
                    }
                    else if (pName.IndexOf("boolean") >= 0)
                    {
                        vs.Add(string.Format("{0}", value.ToLower() == "false" ? "0" : "1"));
                    }
                }
            }
            mySQL.Append(string.Format("({0}) VALUES({1});", string.Join(",", fs), string.Join(",", vs)));
            return mySQL.ToString();
        }
    }
}
