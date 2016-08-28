using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DTO
{
    [Serializable]
    public class UserMenu
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        [FieldInfo(DataFieldLength = 16, FiledName = "ID", Required = true)]
        public Guid? ID
        {
            get; set;
        }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [FieldInfo(DataFieldLength = 20, FiledName = "sMenuName", Required = true)]
        public String sMenuName
        {
            get; set;
        }

        /// <summary>
        /// 上级菜单标识
        /// </summary>
        [FieldInfo(DataFieldLength = 16, FiledName = "sPID", Required = false)]
        public Guid? sPID
        {
            get; set;
        }

        /// <summary>
        /// 对应链接地址
        /// </summary>
        [FieldInfo(DataFieldLength = 50, FiledName = "sUrl", Required = true)]
        public String sUrl
        {
            get; set;
        }

        /// <summary>
        /// 排序编号
        /// </summary>
        [FieldInfo(DataFieldLength = 4, FiledName = "iOrder", Required = true)]
        public Int32? iOrder
        {
            get; set;
        }

        public IList<UserMenu> ChildMenu
        {
            get; set;
        } = new List<UserMenu>();

        public IList<UserMenuButton> Buttons
        {
            get; set;
        } = new List<UserMenuButton>();
    }
}
