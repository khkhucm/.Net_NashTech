using Common;

namespace TestWebAPI.Helpers
{
    public class PagingFilter
    {
        private int _page;
        private int _pageSize;

        public PagingFilter()
        {
            Page = Constants.DefaultPage;
            PageSize = Constants.DefaultPageSize;
        }

        public int Page
        {
            get => _page;
            set => _page = value > 0 ? value : 1;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value >= 10 ? value : Constants.DefaultPageSize;
        }
    }
}
