using Framework.DTO;
using System.Collections.Generic;

namespace Framework.BLL
{
    //自定义的用户按钮对比器
    internal class ButtonsCompare : IEqualityComparer<UserMenuButton>
    {
        public bool Equals(UserMenuButton x, UserMenuButton y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(UserMenuButton obj)
        {
            return obj.GetHashCode();
        }
    }
}