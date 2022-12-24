using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using System.Collections.Generic;

namespace CoreProject.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDbContent appDbContent;
        public CategoryRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => appDbContent.Category;
    }
}
