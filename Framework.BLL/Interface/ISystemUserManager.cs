using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Dapper;
using Framework.DTO;

namespace Framework.BLL
{
    public abstract class ISystemUserManager:BaseBll
    {
        /// <summary>
        /// 分页载入系统用户
        /// </summary>
        /// <param name="page">分页对象</param>
        /// <param name="where">查询条件</param>
        /// <returns>分页结果</returns>
        public abstract PagingRet<EHECD_SystemUserDTO> LoadSystemUsers(PageInfo page,dynamic where);

        /// <summary>
        /// 添加系统用户
        /// </summary>
        /// <param name="user">系统用户</param>
        /// <returns>添加结果</returns>
        public abstract int AddSystemUser(EHECD_SystemUserDTO user,dynamic p);
    }
}
