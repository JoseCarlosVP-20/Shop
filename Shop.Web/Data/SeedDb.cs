namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Identity;

    public class SeedDb
    {

        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            //Adicionar el usuario
            var user = await this.userHelper.GetUserByEmailAsync("josekarlos62@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Jose",
                    LastName = "Villalba",
                    Email = "josekarlos62@gmail.com",
                    UserName = "josekarlos62@gmail.com",
                    PhoneNumber = "84139825"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Cloud not create th user in seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("Iphone XS MAX", user);
                this.AddProduct("Magic Maouse", user);
                this.AddProduct("iWatch Serie 5", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });

        }
    }
}
