using System.Linq;
using QJZ.Framework.Utility;
using TCBase.Saker.Core.AOP;
using WXSchool.Dal.Sys;

namespace WXSchool.Bll.Sys
{
    [AOPClass]
    public class SysUserBiz : TCBase.Saker.Core.Services.Service
    {
        readonly SysUserRespository _respository;

        public SysUserBiz(SysUserRespository respository)
        {
            this._respository = respository;
        }

        public virtual OperationResult Login(string userName, string password)
        {
            var list = _respository.QueryUser(userName);
            if (list == null || !list.Any())
            {
                return new OperationResult(OperationResultType.Error, "用户名不存在。");
            }

            var user = list.First();
            password = Encrypt.MD5(password);
            if (user.Password != password)
            {
                return new OperationResult(OperationResultType.Error, "密码不正确。");
            }

            return new OperationResult(OperationResultType.Success, "登录成功。", user);
        }

        public virtual bool IsExist(string userName)
        {
            var list = _respository.QueryUser(userName);
            if (list == null || !list.Any())
            {
                return false;
            }

            return true;
        }

        public virtual OperationResult ChangePwd(int uId, string password, string newPwd)
        {
            var user = _respository.GetEntityById(uId);
            if (user!=null)
            {
                if (user.Password != Encrypt.MD5(password))
                    return new OperationResult(OperationResultType.Error, "原密码不正确。");

                user.Password = Encrypt.MD5(newPwd);
                _respository.Modify(user);
                return new OperationResult(OperationResultType.Success, "修改成功。");
            }

            return new OperationResult(OperationResultType.Error, "修改失败。");

        }
    }
}
