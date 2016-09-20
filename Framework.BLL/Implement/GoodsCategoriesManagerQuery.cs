using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Dapper;
using Framework.DTO;

namespace Framework.BLL
{
    public partial class GoodsCategoriesManager : IGoodsCategoriesManager
    {
        public override string LoadGoodsCategories()
        {
            var goodsCatories = query.QueryList<EHECD_CategoriesDTO>(@"SELECT ID,PID,sCategoryName,sCategoryCaption,iOrder,sImgUri FROM EHECD_Categories WHERE bIsDeleted = 0", null);
            var ret = LoadLevelCategories(goodsCatories, goodsCatories.Where(m => m.PID == null).FirstOrDefault());
            return JSONHelper.GetJsonString(ret);
        }

        private dynamic LoadLevelCategories(IList<EHECD_CategoriesDTO> categories, EHECD_CategoriesDTO parent)
        {
            var ret = new
            {
                id = parent.ID,
                text = parent.sCategoryName,
                //iconCls = m.sIcon,
                // attributes = new { isLeaf = true, munuid = childMenu[i].ID },
                //@checked = roleMenuButtons != null && roleMenuButtons.Count > 0 ? roleMenuButtons.Contains(m, buttonCompare) : false,
                children = new { }
            };
            for (int i = 0; i < categories.Count; i++)
            {
                if (parent.ID == categories[i].PID)
                {
                    //parent.ChildMenu
                    //ret.Add(categories[i]);
                    //menu[i].ChildMenu = LoadMenuData(menu, menu[i]);
                }
            }
            return ret;
        }


    }
}
