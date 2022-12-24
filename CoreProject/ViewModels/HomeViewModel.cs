using CoreProject.Data.Models;
using System.Collections.Generic;

namespace CoreProject.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavCars { get; set; }
    }
}
