using AppSneackers.Domain.Validations;
using FluentValidation.Results;
using System.Runtime.CompilerServices;

namespace AppSneackers.Domain.Entities
{
    public class Sneacker : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; private set; }

        public string Name { get; private set; }

        public string Brand { get; private set; }

        public decimal Price { get; private set; }

        public decimal Size { get; private set; }

        public int Year { get; private set; }

        public int Rate { get; private set; }

        public virtual User User { get; private set; }

        public static Sneacker CreateNew(int userId, string name, string brand, decimal price, decimal size, int year, int rate)
        {
            Sneacker sneacker = new Sneacker
            {
                UserId = userId,
                Name = name,
                Brand = brand,
                Price = price,
                Size = size,
                Year = year,
                Rate = rate,
            };

            var valid = ValidateModel(sneacker);
            if (!valid.IsValid)
            {
                var ex = string.Join(", ", valid.Errors.Select(sns => sns.ErrorMessage.ToString()));
                throw new ArgumentException(ex);
            }

            return sneacker;
        }

        public void UpdateSneacker(string name, string brand, decimal price, decimal size, int year, int rate)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Size = size;
            Rate = rate;
            Year = year;

            var valid = ValidateModel();
            if (!valid.IsValid)
            {
                var ex = string.Join(", ", valid.Errors.Select(sns => sns.ErrorMessage.ToString()));
                throw new ArgumentException(ex);
            }
        }

        public ValidationResult ValidateModel()
        {
            return new SneackerValidator().Validate(this);
        }

        public static ValidationResult ValidateModel(Sneacker sneacker)
        {
            return new SneackerValidator().Validate(sneacker);
        }
    }
}
