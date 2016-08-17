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
            List<string> fs/*字段名称集合*/ = new List<string>();
            List<string> vs/*值集合*/ = new List<string>();
            PropertyInfo[] pros/*传入对象的属性集合*/ = t.GetType().GetProperties();
            var tbName/*标识表名的自定义特性*/ = t.GetType().GetCustomAttribute<Framework.DTO.TableInfo>();

            mySQL.Append(string.Format("INSERT INTO [{0}]", tbName.TableName));

            foreach (var pro in pros)
            {
                var field/*自定义数据库列特性*/ = pro.GetCustomAttribute<Framework.DTO.FieldInfo>();

                var fvalue/*获取对应属性的值*/ = pro.GetValue(t);
                var value/*获取属性的字符串形式*/ = fvalue != null ? fvalue.ToString() : "";
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value))
                {
                    //列名
                    fs.Add(string.Format("[{0}]", field.FiledName));

                    //获取列类型
                    var pName = pro.PropertyType.GenericTypeArguments.Length > 0 ?
                            pro.PropertyType.GenericTypeArguments[0].Name.ToLower() :
                            pro.PropertyType.Name.ToLower();

                    if (pName == "guid" || pName == "datetime" || pName == "string")
                    {
                        vs.Add(string.Format("'{0}'", value));
                    }
                    else if (pName == "int32" || pName == "int64" ||
                                pName == "int16" || pName == "uint32" ||
                                pName == "uint64" || pName == "uint16" ||
                                pName == "decimal")
                    {
                        vs.Add(string.Format("{0}", value));
                    }
                    else if (pName == "boolean")
                    {
                        vs.Add(string.Format("{0}", value.ToLower() == "false" ? "0" : "1"));
                    }
                    else
                    {
                        vs.Add(string.Format("{0}", value));
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
                    else if (pName.IndexOf("int32") >= 0)
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
