using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core.AOP;
using WXSchool.Dal.Sys;
using WXSchool.Model;

namespace WXSchool.Bll.Sys
{
    [AOPClass]
    public class SysAccessTokenBiz : TCBase.Saker.Core.Services.Service
    {
        readonly SysAccessTokenRespository _respository;

        public SysAccessTokenBiz(SysAccessTokenRespository respository)
        {
            this._respository = respository;
        }

        public SysAccessToken GetAccessToken(int orgId)
        {
            return _respository.GetEntityById(orgId);
        }
    }
}
