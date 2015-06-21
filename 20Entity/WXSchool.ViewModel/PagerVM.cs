using System;
using System.Collections.Generic;

namespace WXSchool.ViewModel
{
    public class PagerVM<TEntity> where TEntity : class, new()
    {
        public List<TEntity> ModelList;

        public PagerInfoVM PagerInfo;
    }

    public class PagerInfoVM
    {
        public int PageSize;
        public int TotalItemCount;
        public int CurrentPageIndex;
        public int TotalPageCount { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }
        public int StartRecordIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }
        public int EndRecordIndex { get { return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount; } }
    }
}
