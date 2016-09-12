using Framework.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO;

namespace Framework.BLL
{
    public abstract class IRoleManager : BaseBll
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public abstract PagingRet<EHECD_RoleDTO> LoadRoles(dynamic where);

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract bool AddRole(dynamic data,dynamic p);

        /// <summary>
        /// 编辑角色信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public abstract bool EditRole(EHECD_RoleDTO role, dynamic p);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="ID">角色ID</param>
        /// <returns></returns>
        public abstract int DeleteRole(string ID, dynamic p);
    }
}
