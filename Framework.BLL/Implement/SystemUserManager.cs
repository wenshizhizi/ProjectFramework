using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Dapper;
using Framework.DTO;
using Framework.Helper;

namespace Framework.BLL
{
    public class SystemUserManager : ISystemUserManager
    {
        //添加用户
        public override int AddSystemUser(EHECD_SystemUserDTO user, dynamic p)
        {
            //1.完善用户信息            
            user.bIsDeleted = false;
            user.dCreateTime = DateTime.Now;
            user.dLastLoginTime = DateTime.Now;
            user.tUserState = 0;
            user.tUserType = 0;
            user.ID = Helper.GuidHelper.GetSecuentialGuid();
            user.sPassWord = Helper.Security.GetMD5Hash(user.sPassWord);

            var sqlIf = @"IF EXISTS(SELECT 1 FROM EHECD_SystemUser WHERE sLoginName = @sLoginName)
                        BEGIN
	                        SELECT -1 RET;
                        END
                        ELSE
                        BEGIN
	                        {0}
                        END;";

            sqlIf = string.Format(sqlIf, Dapper.DBSqlHelper.GetInsertSQL<EHECD_SystemUserDTO>(user));

            //2.保存至数据库
            var ret = excute.Insert(sqlIf, new { sLoginName = user.sLoginName });

            //3.记录系统日志
            InsertSystemLog(
                p.sLoginName.ToString(),
                p.sUserName.ToString(),
                p.IP.ToString(),
                (Int16)(SYSTEM_LOG_TYPE.ADD | SYSTEM_LOG_TYPE.SYSTEMUSER),
                "系统用户添加用户" + user.ID,
                user.ID.ToString(),
                ret > 0);

            return ret;
        }

        //删除用户
        public override int DeleteSystemUser(EHECD_SystemUserDTO user, dynamic p)
        {
            StringBuilder sb = new StringBuilder();
            //1.删除用户
            sb.AppendLine(DBSqlHelper.GetUpdateSQL<EHECD_SystemUserDTO>(new EHECD_SystemUserDTO() { bIsDeleted = true }, string.Format("where ID = '{0}'", user.ID)));

            //2.删除用户的特权 
            sb.AppendLine(DBSqlHelper.GetUpdateSQL<EHECD_PrivilegeDTO>(new EHECD_PrivilegeDTO() { bIsDeleted = true }, string.Format("where ((sPrivilegeMaster = 'user' AND sPrivilegeMasterValue = '{0}') OR (sBelong = 'user' AND sBelongValue = '{0}'))", user.ID)));

            //3.解除用户权限
            sb.AppendLine(DBSqlHelper.GetUpdateSQL<EHECD_SystemUser_R_RoleDTO>(new EHECD_SystemUser_R_RoleDTO() { bIsDeleted = true }, string.Format("where sUserID = '{0}' AND bIsDeleted = 0", user.ID)));

            var ret = excute.ExcuteTransaction(sb.ToString());

            //3.记录系统日志
            InsertSystemLog(
                p.sLoginName.ToString(),
                p.sUserName.ToString(),
                p.IP.ToString(),
                (Int16)(SYSTEM_LOG_TYPE.DELETE | SYSTEM_LOG_TYPE.SYSTEMUSER),
                "系统用户删除用户" + user.ID,
                user.ID.ToString(),
                ret > 0);

            return ret;
        }

        //编辑用户
        public override int EditSystemUser(EHECD_SystemUserDTO user, dynamic p)
        {
            //1.保存至数据库
            var ret = excute.UpdateSingle<EHECD_SystemUserDTO>(user, string.Format("where ID = '{0}'", user.ID));

            //2.记录系统日志
            InsertSystemLog(
                p.sLoginName.ToString(),
                p.sUserName.ToString(),
                p.IP.ToString(),
                (Int16)(SYSTEM_LOG_TYPE.MODIFY | SYSTEM_LOG_TYPE.SYSTEMUSER),
                "系统用户编辑用户" + user.ID,
                user.ID.ToString(),
                ret > 0);

            return ret;
        }

        //冻结用户
        public override int FrozenSystemUser(EHECD_SystemUserDTO user, dynamic p)
        {
            user.tUserState = user.tUserState == 1 ? (byte)0 : (byte)1;

            //1.冻结用户
            var ret = excute.UpdateSingle<EHECD_SystemUserDTO>(user, string.Format("where ID = '{0}'", user.ID));

            //2.记录系统日志
            InsertSystemLog(
                p.sLoginName.ToString(),
                p.sUserName.ToString(),
                p.IP.ToString(),
                (Int16)(SYSTEM_LOG_TYPE.MODIFY | SYSTEM_LOG_TYPE.SYSTEMUSER),
                user.tUserState == 1 ? "系统用户冻结用户" + user.ID : "系统用户解冻用户" + user.ID,
                user.ID.ToString(),
                ret > 0);
            return ret;
        }

        //获取用户信息
        public override EHECD_SystemUserDTO GetSystemUserInfoById(EHECD_SystemUserDTO user)
        {
            user = helper.SingleQuery<EHECD_SystemUserDTO>("SELECT * FROM EHECD_SystemUser WHERE ID = @ID", new { ID = user.ID });
            if (user != default(EHECD_SystemUserDTO))
                return user;
            else
                return null;
        }

        //分页系统用户
        public override PagingRet<EHECD_SystemUserDTO> LoadSystemUsers(PageInfo page, dynamic where)
        {
            return helper.PaginationQuery<EHECD_SystemUserDTO>("SELECT ID,sLoginName,sUserName,tUserState,tUserType,sUserNickName,dCreateTime,dLastLoginTime,sMobileNum FROM EHECD_SystemUser WHERE bIsDeleted = 0 AND sLoginName LIKE @sLoginName", page, new { sLoginName = "%" + where.sLoginName.Value.ToString() + "%" });
        }
    }
}
