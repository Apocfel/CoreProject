using CoreProject.Data.Models;
using System.Collections.Generic;

namespace CoreProject.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> FavCars { get; }
        Car getCarById(int carId);
    }
}
