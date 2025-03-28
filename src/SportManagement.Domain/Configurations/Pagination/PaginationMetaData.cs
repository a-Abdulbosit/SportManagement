namespace SportManagement.Domain.Configurations.Pagination
{
    public class PaginationMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPage;

        public PaginationMetaData(int totalCount, PaginationParams @params)
        {
            TotalCount = totalCount;
            TotalPage = (int)Math.Ceiling(totalCount / (decimal)@params.PageSize);
            CurrentPage = @params.PageIndex;
        }
    }
}
