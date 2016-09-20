using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO;
using Framework.Dapper;
using Framework.Helper;

namespace Framework.BLL
{
    public abstract class IGoodsCategoriesManager:BaseBll
    {
        /// <summary>
        /// 载入商品种类（分页）
        /// </summary>
        /// <param name="pageInfo">分页信息</param>
        /// <returns>载入结果</returns>
        public abstract string LoadGoodsCategories();

    }
}
