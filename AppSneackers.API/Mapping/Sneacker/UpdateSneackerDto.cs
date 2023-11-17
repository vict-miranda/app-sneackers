namespace AppSneackers.API.Mapping.Sneacker
{
    public class UpdateSneackerDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }

        public int Year { get; set; }

        public int Rate { get; set; }
    }
}
