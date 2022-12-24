using CoreProject.Data.Models;
using System.Collections.Generic;

namespace CoreProject.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string currentCategory { get; set; }
    }
}
