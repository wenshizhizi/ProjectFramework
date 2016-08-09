using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DTO
{
    public class OrderGoodDTO
    {
        /// <summary>
        /// ID
        /// </summary>		
        public string ID
        {
            get;
            set;
        }
        /// <summary>
        /// sClientID
        /// </summary>		
        public string sClientID
        {
            get;
            set;
        }
        /// <summary>
        /// 订单ID
        /// </summary>		
        public string sOrderID
        {
            get;
            set;
        }
        /// <summary>
        /// 订单号
        /// </summary>		
        public string sOrderNo
        {
            get;
            set;
        }
        /// <summary>
        /// 商品ID、套餐活动ID、促销商品ID
        /// </summary>		
        public string sGoodsPrimaryKey
        {
            get;
            set;
        }
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
        /// <summary>
        /// 商品颜色
        /// </summary>		
        public string sColorValue
        {
            get;
            set;
        }
        /// <summary>
        /// 商品尺寸
        /// </summary>		
        public string sSizeName
        {
            get;
            set;
        }
        /// <summary>
        /// 总价（暂未使用）
        /// </summary>		
        public decimal? dTotalPrice
        {
            get;
            set;
        }
        /// <summary>
        /// bIsDeleted
        /// </summary>		
        public bool? bIsDeleted
        {
            get;
            set;
        }
        /// <summary>
        /// 商品类别：1.普通商品 2.促销商品 3.套餐商品
        /// </summary>		
        public int? iGoodsType
        {
            get;
            set;
        }
    }
}
