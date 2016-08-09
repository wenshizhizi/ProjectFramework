using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public class Order
    {
        public string sOrderNo { get; set; }

        public string sClientLoginName { get; set; }

        public List<OrderGood> orderGoods { get; set; }

        public RecevierAddress Address { get; set; }


        public void CreateOrder(params object[] parameter)
        {
            
        }


    }
}
