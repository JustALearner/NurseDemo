using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurse.Common
{
    public class PagedList<T> : List<T> where T : class
    {



        public int PerPageSize { get; set; }
        public int PageIndex { get; set; }
        private int _totalItemCount;

        public int TotalItemCount
        {
            get => _totalItemCount;
            set => _totalItemCount = value > 0 ? value : 0;
        }

        private int _pageCount;

        public int PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }
        private bool _hasPrevious;

        public bool HasPrevious
        {
            get { return _hasPrevious; }
            set { _hasPrevious = value; }
        }
        private bool _hasNext;

        public bool HasNext
        {
            get { return _hasNext; }
            set { _hasNext = value; }
        }

        //        public  int PageCount => TotalItemCount / PerPageSize + (TotalItemCount%PerPageSize > 0 ? 1 : 0);
        //        public bool HasPrevious => PageIndex > 0;
        //        public bool HasNext => PageIndex < PageCount-1;

        public PagedList(int pageIndex, int pageSize, int totalItemsCount, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            PerPageSize = pageSize;
            TotalItemCount = totalItemsCount;
            AddRange(data);
            PageCount = TotalItemCount / PerPageSize + (TotalItemCount % PerPageSize > 0 ? 1 : 0);
            HasPrevious = PageIndex > 1;
            HasNext = PageIndex < PageCount - 1;
        }
    }
}
