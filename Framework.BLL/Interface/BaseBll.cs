using Framework.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.BLL
{
    public class BaseBll
    {
        protected Dapper.QueryHelper helper = DIEntity.GetInstance().GetImpl<Dapper.QueryHelper>();
        protected Dapper.ExcuteHelper excute = DIEntity.GetInstance().GetImpl<Dapper.ExcuteHelper>();
    }
}
