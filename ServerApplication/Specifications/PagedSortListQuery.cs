using System;

namespace ServerApplication.Specifications
{
    public class PagedSortListQuery
    {
        const int DefaultSkip = 0;
        const int DefaultTake = 10;
        const string DefaultOrder = "desc";

        public int Skip { get; set; } = DefaultSkip;
        public int Take { get; set; } = DefaultTake;
        public string SortProp { get; set; }

        public string SortOrder { get; set; } = DefaultOrder;


        public PagedSortListQuery TakeAll()
        {
            Skip = 0;
            Take = Int32.MaxValue;
            return this;
        }
    }
}
