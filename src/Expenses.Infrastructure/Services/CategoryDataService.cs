using Expenses.Domain.Interfaces;
using Expenses.Domain.Models;
using Expenses.Infrastructure.Data;
using Expenses.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expenses.Infrastructure.Models.Extensions;

namespace Expenses.Infrastructure.Services
{
    public class CategoryDataService : ICategoryDataService
    {
        public async Task AddCategory(string categoryName)
        {
            var context = new ExpensesContext();

            var category = new CategoryDto() { Name = categoryName };
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public IEnumerable<Category> GetCategories()
        {
            var context = new ExpensesContext();

            return context.Categories
                .OrderBy(x => x.Name)
                .Include(cat => cat.Subcategories).ToDomainModel();
        }

        public async Task DeleteCategory(uint id)
        {
            var context = new ExpensesContext();

            var currentCategory = await context.Categories.FindAsync(id);
            context.Categories.Remove(currentCategory);
            await context.SaveChangesAsync();

            Log.Debug($"Deleted category: {currentCategory.Name}");
        }

        public async Task AddSubCategory(string subCategoryName, uint parentCategoryId)
        {
            var context = new ExpensesContext();

            var category = context.Categories.First(x => x.Id == parentCategoryId);

            if (category.Subcategories == null)
                category.Subcategories = new List<SubcategoryDto>();

            category.Subcategories.Add(new SubcategoryDto { Name = subCategoryName });

            context.Categories.Update(category);

            await context.SaveChangesAsync();
        }

        public List<Subcategory> GetSubCategoriesFor(uint categoryId)
        {
            var context = new ExpensesContext();

            var categoryDto = context.Categories.First(x => Equals(x.Id, categoryId));

            return categoryDto.Subcategories.OrderBy(x => x.Name).ToDomainModel();
        }

        public async Task DeleteSubCategory(uint id)
        {
            var context = new ExpensesContext();

            var currentCategory = await context.Subcategories.FindAsync(id);
            context.Subcategories.Remove(currentCategory);
            await context.SaveChangesAsync();

            Log.Debug($"Deleted subcategory: {currentCategory.Name}");
        }
    }
}
