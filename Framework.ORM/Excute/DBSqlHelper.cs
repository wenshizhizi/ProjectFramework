using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Framework.Helper;

namespace Framework.Dapper
{
    public static class DBSqlHelper
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
            PropertyInfo[] pros = t.GetType().GetProperties();
            var tbName = t.GetType().GetCustomAttribute<Framework.DTO.TableInfo>();

            mySQL.Append(string.Format("INSERT INTO [{0}]", tbName.TableName));

            foreach (var pro in pros)
            {
                var field = pro.GetCustomAttribute<Framework.DTO.FieldInfo>();

                var fvalue = pro.GetValue(t);
                var value = fvalue != null ? fvalue.ToString() : "";
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    fs.Add(string.Format("[{0}]", field.FiledName));
                    var pName = pro.PropertyType.FullName.ToLower();

                    if (pName.IndexOf("guid") >= 0 || pName.IndexOf("datetime") >= 0 || pName.IndexOf("string") >= 0)
                    {
                        vs.Add(string.Format("'{0}'", value));
                    }
                    else if (pName.IndexOf("int") >= 0 || pName.IndexOf("byte") >= 0)
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

        /// <summary>
        /// 传入实体类获取更新sql
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetUpdateSQL<T>(T t, string where)
        {
            StringBuilder mySQL = new StringBuilder();
            List<string> setStrArray = new List<string>();

            PropertyInfo[] pros = t.GetType().GetProperties();
            var tbName = t.GetType().GetCustomAttribute<Framework.DTO.TableInfo>();

            mySQL.Append(string.Format("UPDATE [{0}] SET ", tbName.TableName));

            foreach (var pro in pros)
            {
                var field = pro.GetCustomAttribute<Framework.DTO.FieldInfo>();

                var fvalue = pro.GetValue(t);
                var value = fvalue != null ? fvalue.ToString() : "";
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    var pName = pro.PropertyType.FullName.ToLower();
                    if (pName.IndexOf("guid") >= 0 || pName.IndexOf("datetime") >= 0 || pName.IndexOf("string") >= 0)
                    {
                        setStrArray.Add(string.Format("[{0}] = '{1}'", field.FiledName, value));
                    }
                    else if (pName.IndexOf("int") >= 0 ||
                                pName.IndexOf("byte") >= 0)
                    {
                        setStrArray.Add(string.Format("[{0}] = {1}", field.FiledName, value));
                    }
                    else if (pName.IndexOf("boolean") >= 0)
                    {
                        setStrArray.Add(string.Format("[{0}] = {1}", field.FiledName, value.ToLower() == "true" ? 1 : 0));
                    }
                }
            }
            mySQL.Append(string.Join(",", setStrArray) + (where.StartsWith(" ") ? "" : " "));
            mySQL.Append(where + ";");
            return mySQL.ToString();
        }
    }
}
