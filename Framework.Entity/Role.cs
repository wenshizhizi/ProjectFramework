using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entity
{
    public class Role
    {
        [FieldInfo(DataFieldLength = int.MaxValue, DataFieldType = typeof(int), IsDataFieldNecessary = true)]
        public int RoleId { get; set; }

        [FieldInfo(DataFieldLength = 256, DataFieldType = typeof(String), IsDataFieldNecessary = true)]
        public string RoleName { get; set; }
    }
}
