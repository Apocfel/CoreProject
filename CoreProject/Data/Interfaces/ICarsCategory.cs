using CoreProject.Data.Models;
using System.Collections.Generic;

namespace CoreProject.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
