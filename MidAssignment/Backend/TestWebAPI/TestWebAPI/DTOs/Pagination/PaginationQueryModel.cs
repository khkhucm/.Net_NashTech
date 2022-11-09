using Common;
using Common.Enums;

namespace TestWebAPI.DTOs.Pagination
{
    public class PaginationQueryModel
    {
        private int _page;
        private int _pageSize;

        public int Page
        {
            get => _page;
            set => _page = value > 0 ? value : Constants.DefaultPage;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value >= 10 ? value : Constants.DefaultPageSize;
        }

        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public SortEnum? SortOption { get; set; }

    }
}
