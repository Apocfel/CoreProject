using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoreProject.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContent appDbContent;
        public CarRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Car> Cars => appDbContent.Car.Include(c => c.Category);
        public IEnumerable<Car> FavCars => appDbContent.Car.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car getCarById(int carId)
        {
            return appDbContent.Car.FirstOrDefault(p => p.Id == carId);
        }
    }
}
