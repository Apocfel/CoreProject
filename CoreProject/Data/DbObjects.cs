using CoreProject.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreProject.Data
{
    public static class DbObjects
    {
        private const string DEFAULT_AUTOMOBILE = "/img/emobile.jpg";
        private const string DEFAULT_EMOBILE = "/img/amobile.webp";
        public static void Initial(AppDbContent content)
        {

            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Car.Any())
                content.AddRange(
                    new Car
                    {
                        Name = "Emobile",
                        Description = "Emobile default description",
                        Price = 500,
                        IsFavourite = true,
                        IsAvaiable = true,
                        Img = DEFAULT_EMOBILE,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "Emobile-2",
                        Price = 700,
                        IsFavourite = true,
                        IsAvaiable = true,
                        Img = DEFAULT_EMOBILE,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "AutoMobile-1",
                        Price = 800,
                        IsFavourite = true,
                        IsAvaiable = true,
                        Img = DEFAULT_AUTOMOBILE,
                        Category = Categories["Автомобили"]
                    },
                    new Car
                    {
                        Name = "AutoMobile-2",
                        Price = 1200,
                        IsFavourite = true,
                        IsAvaiable = true,
                        Img = DEFAULT_AUTOMOBILE,
                        Category = Categories["Автомобили"]
                    }
                );
            if (!content.User.Any())
                content.User.AddRange(Users.Select(u => u.Value));
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category != null)
                    return category;
                var list = new Category[]
                {
                    new Category {Name = "Электромобили", Description = "Автомобили использующие электричество как топливо."},
                    new Category {Name = "Автомобили", Description = "Классические автомобили."}
                };
                category = new Dictionary<string, Category>();
                foreach (Category el in list)
                {
                    category.Add(el.Name, el);
                }

                return category;
            }
        }
        private static Dictionary<string, User> user;
        public static Dictionary<string, User> Users
        {
            get
            {
                if (user != null)
                    return user;
                var list = new User[]
                {
                    new User
                    {
                        Username = "Ivan",
                        Email = "ivan@mail.ru",
                        Password = "ivan123",
                        DisplayName = "Ivan!",
                        Role = "Standart"
                    },
                    new User
                    {
                        Username = "Admin",
                        Email = "admin@mail.ru",
                        Password = "admin123",
                        DisplayName = "Admin!",
                        Role = "Admin"
                    },
                    new User
                    {
                        Username = "Alex",
                        Email = "alex@mail.ru",
                        Password = "Alex123",
                        DisplayName = "Alex!",
                        Role = "Standart"
                    }
                };
                user = new Dictionary<string, User>();
                foreach (User element in list)
                {
                    user.Add(element.Username, element);
                }

                return user;
            }
        }
    }
}
