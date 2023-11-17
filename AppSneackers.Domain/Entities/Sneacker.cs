namespace AppSneackers.Domain.Entities
{
    public class Sneacker
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }

        public string Name { get; private set; }

        public string Brand { get; private set; }

        public decimal Price { get; private set; }

        public decimal Size { get; private set; }

        public int Year { get; private set; }

        public int Rate { get; private set; }

        public virtual User User { get; private set; }
    }
}
