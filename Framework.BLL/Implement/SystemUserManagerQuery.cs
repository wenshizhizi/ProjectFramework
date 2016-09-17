using Framework.Dapper;
using Framework.DTO;

namespace Framework.BLL
{
    public partial class SystemUserManager:ISystemUserManager
    {
        //获取用户信息
        public override EHECD_SystemUserDTO GetSystemUserInfoById(EHECD_SystemUserDTO user)
        {
            user = query.SingleQuery<EHECD_SystemUserDTO>("SELECT * FROM EHECD_SystemUser WHERE ID = @ID", new { ID = user.ID });
            return user != default(EHECD_SystemUserDTO) ? null : user;            
        }

        //分页系统用户
        public override PagingRet<EHECD_SystemUserDTO> LoadSystemUsers(PageInfo page, dynamic where)
        {
            return query.PaginationQuery<EHECD_SystemUserDTO>("SELECT ID,sLoginName,sUserName,tUserState,tUserType,sUserNickName,dCreateTime,dLastLoginTime,sMobileNum FROM EHECD_SystemUser WHERE bIsDeleted = 0 AND sLoginName LIKE @sLoginName", page, new { sLoginName = "%" + where.sLoginName.Value.ToString() + "%" });
        }
    }
}
