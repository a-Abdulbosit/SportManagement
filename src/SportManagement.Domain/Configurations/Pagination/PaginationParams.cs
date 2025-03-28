namespace SportManagement.Domain.Configurations.Pagination
{
    public class PaginationParams
    {
        public const int maxPageSize = 20;
        private int pageSize;

        public int PageSize
        {
            get => pageSize == 0 ? 10 : pageSize; 
            set => pageSize = value > maxPageSize ? maxPageSize : value;
        }

        public int PageIndex { get; set; }
    }

}
