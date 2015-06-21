using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using QJZ.Framework.Utility;
using TCSmartFramework.DataAccess;
using WXSchool.ViewModel;

namespace WXSchool.Dal
{
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class PagerRespository<TEntity> where TEntity : class, new()
    {
        private static DataSet Query(string tableName
            , string order
            , int pageSize
            , int pageIndex
            , string condition
            , string returnFields)
        {
            var sql = new StringBuilder();
            sql.AppendFormat("DECLARE	@TotalRecord int;{0}", Environment.NewLine);
            sql.AppendFormat("SET	@TotalRecord = 0;{0}", Environment.NewLine);
            sql.AppendFormat(
                    "EXEC	[dbo].[P_PAGEQUERY] @TableName = N'{0}',  @ReFieldsStr = N'{1}', @OrderString = N'{2}',  @WhereString = N'{3}', @PageSize = {4}, @PageIndex = {5}, @TotalRecord = @TotalRecord OUTPUT; {6}",
                    tableName, returnFields, order, condition, pageSize, pageIndex, Environment.NewLine);
            sql.Append("SELECT	@TotalRecord as N'@TotalRecord'");

            return SqlHelper.ExecuteDataSet(sql.ToString());
        }

        public static PagerVM<TEntity> PagerQuery(string tableName
            , string order
            , int pageSize = 20
            , int pageIndex = 1
            , string condition = "1=1"
            , string returnFields = "*")
        {
            var vm = new PagerVM<TEntity>();
            DataSet ds = Query(tableName, order, pageSize, pageIndex, condition, returnFields);
            if (ds != null)
            {
                var table = ds.Tables[0];
                if (table.Columns.Contains("rowId"))
                {
                    table.Columns.RemoveAt(0);
                }
                var totalRecord = ds.Tables[1].Rows[0][0];

                vm.ModelList = ToList(table);
                vm.PagerInfo = new PagerInfoVM
                {
                    PageSize = pageSize,
                    CurrentPageIndex = pageIndex,
                    TotalItemCount = Converter.ToInt(totalRecord.ToString())
                };
            }

            return vm;
        }

        private static List<TEntity> ToList(DataTable dt)
        {
            var prlist = new List<PropertyInfo>();
            Type t = typeof(TEntity);
            Array.ForEach(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            var oblist = new List<TEntity>();
            foreach (DataRow row in dt.Rows)
            {
                var ob = new TEntity();
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                oblist.Add(ob);
            }

            return oblist;
        }
    }
}
