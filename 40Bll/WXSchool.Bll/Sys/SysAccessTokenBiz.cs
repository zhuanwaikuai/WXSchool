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

        public virtual SysAccessToken GetAccessToken(int orgId)
        {
            return _respository.GetEntityById(orgId);
        }

        public virtual IEnumerable<dynamic> GetAccessTokens(string name)
        {
            return _respository.QueryAccessTokens(name);
        }

        public virtual OperationResult AddAccessToken(SysAccessToken token)
        {
            string msg = "操作成功！";
            try
            {
                token.LastTime = DateTime.Now;
                //_respository.Add(token);
                _respository.Insert(token);
                return new OperationResult(OperationResultType.Success, msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new OperationResult(OperationResultType.Error, msg);
        }
    }
}
