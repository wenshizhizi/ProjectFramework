using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entity
{
    /// <summary>
    /// 数据字段信息
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldInfo:Attribute
    {
        /// <summary>
        /// 数据字段类型
        /// </summary>
        public Type DataFieldType { get; set; }

        /// <summary>
        /// 数据字段长度
        /// </summary>
        public int DataFieldLength { get; set; }

        /// <summary>
        /// 数据字段是否是必填(不能为空)
        /// </summary>
        public Boolean IsDataFieldNecessary { get; set; }
    }
}
