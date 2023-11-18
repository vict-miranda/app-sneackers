using AppSneackers.Domain.Validations;
using AppSneackers.Domain.ValueObjects;
using FluentValidation.Results;

namespace AppSneackers.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; } = string.Empty;

        public string Password { get; private set; }

        public Contact Contact { get; set; }

        public virtual List<Sneacker> Sneackers { get; private set; }

        public User()
        {
            Sneackers = new List<Sneacker>();
        }

        public static User CreateNew(string firstName, string lastName, string email, string password)
        {
            User user = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Contact = new()
                {
                    Address = new("a", "b", "c", "d", "e"),
                    MobilePhone = new(56, 65465465)
                }
            };
            return user;
        }

        public void AddSneacker(string name, string brand, decimal price, decimal size, int year, int rate)
        {
            Sneackers.Add(Sneacker.CreateNew(Id, name, brand, price, size, year, rate));
        }

        public void UpdateSneacker(int id, string name, string brand, decimal price, decimal size, int year, int rate)
        {
            if (Sneackers == null || Sneackers.Count <= 0)
            {
                return;
            }

            Sneacker sneacker = Sneackers.Where(x => x.Id == id).SingleOrDefault();
            if (sneacker == null)
            {
                return;
            }

            sneacker.UpdateSneacker(name, brand, price, size, year, rate);
        }

        public void RemoveSneacker(int snickerId)
        {
            //Sneackers.Where(x => x.Id != snickerId).ToList();
            Sneackers.RemoveAll(x => x.Id == snickerId);
        }

        public ValidationResult ValidateModel()
        {
            return new UserValidator().Validate(this);
        }

        //public Contact SetContact(string name, string brand, decimal price, decimal size, int year, int rate)
        //{
        //    var contact = new Contact
        //    {
        //        Address = new("a", "b", "c", "d", "e"),
        //        HomePhone = new(56, 65465465),
        //        MobilePhone = new(56, 65465465),
        //        WorkPhone = new(56, 65465465),
        //    };
        //    return contact;
        //}
    }
}
