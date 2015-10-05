using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCBase.Saker.Core.AOP;
using WXSchool.Dal.Sys;
using WXSchool.Model.Sys;

namespace WXSchool.Bll.Sys
{
    /// <summary>
    /// 系统参数业务逻辑
    /// </summary>
    [AOPClass]
    public class SysParametersBiz : TCBase.Saker.Core.Services.Service
    {
        /// <summary>
        /// 缓存key
        /// </summary>
        private const string CacheKey = "Hot371.AllParameters";

        readonly SysParametersRespository _respository;

        public SysParametersBiz(SysParametersRespository respository)
        {
            this._respository = respository;
        }

        /// <summary>
        /// 获取全部放缓存 1小时
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<SysParameters> GetAll()
        {
            //var cache = Caching.Get(CacheKey) as IEnumerable<SysParameters>;
            //if (cache != null)
            //{
            //    return cache;
            //}

            var all = _respository.GetAll()
                .Where(p => p.IsDeleted == 0)
                .OrderBy(p => p.GroupId)
                .ThenBy(p => p.Sort);
            //try
            //{
            //    Caching.Set(CacheKey, all, 60);
            //}
            //catch (Exception)
            //{
            //}
            return all;
        }

        /// <summary>
        /// 根据分组获取
        /// </summary>
        /// <param name="gId"></param>
        /// <returns></returns>
        public virtual IEnumerable<SysParameters> GetByGroup(int gId)
        {
            var all = GetAll();
            if (gId > 0)
            {
                var paras = all.Where(p => p.GroupId == gId);
                return paras;
            }
            return all;
        }

        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public virtual SysParameters GetById(int pId)
        {
            return _respository.GetEntityById(pId);
        }

        /// <summary>
        /// 维护
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual OperationResult Edit(SysParameters parameter)
        {
            parameter.IsDeleted = 0;
            if (parameter.PId > 0)
            {
                _respository.Modify(parameter);
            }
            else
            {
                var pId = _respository.Add(parameter);
                parameter.PId = pId;
            }

            //Caching.Remove(CacheKey);
            return new OperationResult(OperationResultType.Success, "操作成功");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pId"></param>
        public virtual OperationResult Delete(int pId)
        {
            var parameter = _respository.GetEntityById(pId);
            parameter.IsDeleted = 1;
            _respository.Modify(parameter);
            //Caching.Remove(CacheKey);

            return new OperationResult(OperationResultType.Success, "删除成功");
        }
    }
}
