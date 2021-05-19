namespace mcq_backend.Helper.AppHelper
{
    public class PaginationHelper
    {
        //Maximum return value
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; }
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}