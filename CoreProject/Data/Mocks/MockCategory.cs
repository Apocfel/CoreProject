using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using System.Collections.Generic;

namespace CoreProject.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {
                    new Category {Name = "Электромобили", Description = "Автомобили использующие электричество как топливо."},
                    new Category {Name = "Автомобили", Description = "Классические автомобили."}
                };
            }
        }
    }
}
