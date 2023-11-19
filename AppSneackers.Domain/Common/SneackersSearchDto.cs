namespace AppSneackers.Domain.Common
{
    public class SneackersSearchDto
    {
        public int UserId { get; set; }
        public string? Search { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public List<SortBy?> SortBy { get; set; } = new List<SortBy?>();
    }
}
