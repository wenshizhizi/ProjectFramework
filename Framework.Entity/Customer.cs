using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Entity
{
    public class Customer
    {       
        public int UserId { get; set; }

        [FieldInfo(DataFieldLength = 256, DataFieldType = typeof(String), IsDataFieldNecessary = true)]
        public string UserName { get; set; }

        [FieldInfo(DataFieldLength = 500, DataFieldType = typeof(String), IsDataFieldNecessary = false)]
        public string Password { get; set; }
                
        public string Email { get; set; }
               
        public string PhoneNumber { get; set; }
                
        public bool IsFirstTimeLogin { get; set; }
                
        public int AccessFailedCount { get; set; }
               
        public DateTime CreationDate { get; set; }
                
        public bool IsActive { get; set; }

        public Role Role { get; set; }
    }
}
