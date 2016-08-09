using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.MapperConfig
{
    public class MapperHelpper
    {
        public static T Map<T>(Object value)
        {
            return AutoMapper.Mapper.Map<T>(value);
        }
    }
}
