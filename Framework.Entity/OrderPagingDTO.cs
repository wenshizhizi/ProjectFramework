using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DTO
{
    public class OrderPagingDTO
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
        /// 订单号
        /// </summary>		
        public string sOrderNo
        {
            get;
            set;
        }
        /// <summary>
        /// 购买人ID
        /// </summary>		
        public string sClientID
        {
            get;
            set;
        }
        /// <summary>
        /// 类型：0.游客1.客户 2.销售 3.经销商 4.分公司
        /// </summary>		
        public int? iClientType
        {
            get;
            set;
        }
        /// <summary>
        /// 客户登录名
        /// </summary>		
        public string sClientLoginName
        {
            get;
            set;
        }
        /// <summary>
        /// 订单支付总价格
        /// </summary>		
        public decimal? iTotalPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 订单原价
        /// </summary>		
        public decimal? iOriginalTotalPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 订单积分数量（未使用）
        /// </summary>		
        public int? iScore
        {
            get;
            set;
        }
        /// <summary>
        /// 订单秒杀占用价格
        /// </summary>		
        public decimal? iSeckillTotalPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 发货填写备注
        /// </summary>		
        public string sSendDescribe
        {
            get;
            set;
        }
        /// <summary>
        /// 发货时间
        /// </summary>		
        public DateTime? dSendTime
        {
            get;
            set;
        }
        /// <summary>
        /// 订单下单时间
        /// </summary>		
        public DateTime? dBookTime
        {
            get;
            set;
        }
        /// <summary>
        /// 付款时间
        /// </summary>		
        public DateTime? dPayTime
        {
            get;
            set;
        }
        /// <summary>
        /// 订单完成时间
        /// </summary>		
        public DateTime? dFinishTime
        {
            get;
            set;
        }
        /// <summary>
        /// 收货人
        /// </summary>		
        public string sReceiver
        {
            get;
            set;
        }
        /// <summary>
        /// 收货人电话
        /// </summary>		
        public string sReceiverPhone
        {
            get;
            set;
        }
        /// <summary>
        /// 收货地区 - 省
        /// </summary>		
        public string sReceiveProvince
        {
            get;
            set;
        }
        /// <summary>
        /// 收货地区 - 市
        /// </summary>		
        public string sReceiveCity
        {
            get;
            set;
        }
        /// <summary>
        /// 收货地区- 区县
        /// </summary>		
        public string sReceiveRegion
        {
            get;
            set;
        }
        /// <summary>
        /// 收货详细地址
        /// </summary>		
        public string sReceiverAddress
        {
            get;
            set;
        }
        /// <summary>
        /// 收货方式：1.公司配送运费设置 2.自提设置 3.快递设置 4.货运设置
        /// </summary>		
        public int? iReceiverMethods
        {
            get;
            set;
        }
        /// <summary>
        /// 订单下单备注
        /// </summary>		
        public string sDescribe
        {
            get;
            set;
        }
        /// <summary>
        /// 订单状态  1:待付款 2:已付款(已审核)并且待发货 3:已发货 4:已完成（待评价） 5:已完成（已经评价） 6:已取消 
        /// </summary>		
        public int? iState
        {
            get;
            set;
        }
        /// <summary>
        /// 标注(取值为0-5，分别表示不同颜色的小旗)
        /// </summary>		
        public int? iFlag
        {
            get;
            set;
        }
        /// <summary>
        /// 数据来源(1-PC,2-网页，3-Android,4-IOS)
        /// </summary>		
        public int? iSource
        {
            get;
            set;
        }
        /// <summary>
        /// 物流配送ID
        /// </summary>		
        public string sLogisticsID
        {
            get;
            set;
        }
        /// <summary>
        /// 订单物流占用价格
        /// </summary>		
        public decimal? iLogisticsPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 物流配送名称
        /// </summary>		
        public string sLogisticsName
        {
            get;
            set;
        }
        /// <summary>
        /// 物流配送Code
        /// </summary>		
        public string sLogisticsCode
        {
            get;
            set;
        }
        /// <summary>
        /// 物流单号
        /// </summary>		
        public string sLogisticsOrderNo
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
        /// 打印次数
        /// </summary>		
        public int? iPrintNumbers
        {
            get;
            set;
        }
        /// <summary>
        /// 订单完成后，获得积分
        /// </summary>		
        public int? iGetScope
        {
            get;
            set;
        }
        /// <summary>
        /// 订单支付时，所消耗积分
        /// </summary>		
        public int? iSpendScope
        {
            get;
            set;
        }
        /// <summary>
        /// 订单积分折扣占用金额
        /// </summary>		
        public decimal? iScoreDiscountPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 用户订单优惠券iD
        /// </summary>		
        public string sCouponDetailID
        {
            get;
            set;
        }
        /// <summary>
        /// 用户订单优惠券抵扣金额
        /// </summary>		
        public decimal? iCouponDiscountPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 订单打包费
        /// </summary>		
        public decimal? iBaggingPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 是否在客户端显示出来
        /// </summary>		
        public bool? bIsClientDelete
        {
            get;
            set;
        }
        /// <summary>
        /// 提成支出 向上级支出
        /// </summary>		
        public decimal? dRoyaltyOutput
        {
            get;
            set;
        }
        /// <summary>
        /// 订单商品的条件，以逗号分隔
        /// </summary>		
        public string sBarCodes
        {
            get;
            set;
        }
        /// <summary>
        /// 上级分公司ID
        /// </summary>		
        public string sBranchCompanyID
        {
            get;
            set;
        }
        /// <summary>
        /// 上级经销商ID
        /// </summary>		
        public string sDealerID
        {
            get;
            set;
        }
        /// <summary>
        /// 上级销售ID
        /// </summary>		
        public string sSuperiorSalesID
        {
            get;
            set;
        }
        /// <summary>
        /// 订单下所有商品的名称，以逗号分隔
        /// </summary>		
        public string sGoodsNameList
        {
            get;
            set;
        }

        public string sBuyerID
        {
            get;
            set;
        }

        public int MaxCount { get; set; }
    }
}
