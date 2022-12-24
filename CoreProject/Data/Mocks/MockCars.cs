using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreProject.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private const string DEFAULT_AUTOMOBILE = "/img/emobile.jpg";
        private const string DEFAULT_EMOBILE = "/img/amobile.webp";
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars
        {
            get => new List<Car>
                {
                    new Car {
                        Name = "Emobile",
                        Price = 500,
                        IsFavourite = true,
                        IsAvaiable = true,
                        Img = DEFAULT_EMOBILE,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        Name = "Emobile-2",
                        Price = 700,
                        IsFavourite = true,
                        IsAvaiable = true,
                        Img = DEFAULT_EMOBILE,
                        Category = _categoryCars.AllCategories.First()
                    },
                    new Car {
                        Name = "AutoMobile-1",
                        Price = 800,
                        IsFavourite = true,
                        IsAvaiable = true,
                        Img = DEFAULT_AUTOMOBILE,
                        Category = _categoryCars.AllCategories.Last()
                    },
                    new Car {
                        Name = "AutoMobile-2",
                        Price = 1200,
                        IsFavourite = true,
                        IsAvaiable = true,
                        Img = DEFAULT_AUTOMOBILE,
                        Category = _categoryCars.AllCategories.Last()
                    },
                };

            set => throw new System.NotImplementedException();
        }
        public IEnumerable<Car> FavCars { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Car getCarById(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
