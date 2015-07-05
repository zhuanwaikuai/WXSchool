using System.Collections.Generic;
using TCBase.Saker.Core.Persistence;
using WXSchool.Model;

namespace WXSchool.Dal.Sys
{
    public class SysAccessTokenRespository : Respository<SysAccessToken>
    {
        public IEnumerable<dynamic> QueryAccessTokens(string name)
        {
            var sql = "select b.OrgName,a.OrgId,a.AppID,a.LastTime " +
                      "from SysAccessToken a " +
                      "join SysOrganization b on a.OrgId=b.OrgId";
            if (!string.IsNullOrWhiteSpace(name))
            {
                sql += "where b.OrgName like '%@name%'";
            }

            return base.GetList<dynamic>(sql, new { name });
        }

        public void Insert(SysAccessToken token)
        {
            var sql =
                "INSERT INTO [SysAccessToken] " +
                "([OrgId],[AppID],[AppSecret],[AppToken], [LastTime],[TemplateId1]) " +
                "VALUES(@OrgId,@AppID,@AppSecret,@AppToken,getdate(),@TemplateId1)";

            base.Execute(sql, new {token.OrgId,token.AppID,token.AppSecret,token.AppToken,token.TemplateId1});
        }
    }
}
