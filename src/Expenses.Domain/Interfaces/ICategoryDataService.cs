using Expenses.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.Domain.Interfaces
{
    public interface ICategoryDataService
    {
        Task AddCategory(string categoryName);
        IEnumerable<Category> GetCategories();

        Task DeleteCategory(uint id);

        Task AddSubCategory(string subCategoryName, uint parentCategoryId);

        List<Subcategory> GetSubCategoriesFor(uint categoryId);

        Task DeleteSubCategory(uint id);

    }
}
