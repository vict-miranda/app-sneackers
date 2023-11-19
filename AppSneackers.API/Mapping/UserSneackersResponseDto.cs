using AppSneackers.API.Mapping.Sneacker;

namespace AppSneackers.API.Mapping
{
    public class UserSneackersResponseDto
    {
        public int UserId { get; set; }
        public List<SneackerDto> Sneackers { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public int? TotalRecords { get; set; }
    }
}
