using System.Collections.Generic;
using TCBase.Saker.Core.Persistence;
using WXSchool.Model.Sys;

namespace WXSchool.Dal.Sys
{
    public class SysUserRespository : Respository<SysUser>
    {
        public IEnumerable<SysUser> QueryUser(string userName)
        {
            var sql = "select * from dbo.SysUser where UserName=@UserName";
            return base.GetList<SysUser>(sql, new { userName });
        }
    }
}
