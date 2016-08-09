using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public class OrderGood
    {
        /// <summary>
        /// 商品编号（套餐商品以逗号分隔）
        /// </summary>		
        public string sGoodsNo
        {
            get;
            set;
        }
        /// <summary>
        /// 商品名称
        /// </summary>		
        public string sGoodsName
        {
            get;
            set;
        }
        /// <summary>
        /// 商品单价
        /// </summary>		
        public decimal? iSinglePrice
        {
            get;
            set;
        }
        /// <summary>
        /// 商品数量
        /// </summary>		
        public int? iAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 可退数量
        /// </summary>		
        public int? iReturnAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 商品规格
        /// </summary>		
        public string sGoodStandID
        {
            get;
            set;
        }
    }
}
