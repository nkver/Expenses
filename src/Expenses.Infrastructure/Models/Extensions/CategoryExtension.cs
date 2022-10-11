using Expenses.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Infrastructure.Models.Extensions
{
    public static class CategoryExtension
    {

        public static CategoryDto ToDto(this Category input)
        {
            return new CategoryDto { Id = input.Id, Name = input.Name, Subcategories = input.Subcategories.ToDto() };
        }

        public static IEnumerable<CategoryDto> ToDto(this IEnumerable<Category> input)
        {
            return input.Select(ToDto);
        }

        public static Category ToDomainModel(this CategoryDto input)
        {
            return new Category(input.Id, input.Name, input.Subcategories?.ToDomainModel());
        }

        public static List<Category> ToDomainModel(this IEnumerable<CategoryDto> input)
        {
            return input.Select(ToDomainModel).ToList();
        }

        public static SubcategoryDto ToDto(this Subcategory input)
        {
            return new SubcategoryDto { Id = input.Id, Name = input.Name };
        }

        public static List<SubcategoryDto> ToDto(this IEnumerable<Subcategory> input)
        {
            return input.Select(ToDto).ToList();
        }


        public static Subcategory ToDomainModel(this SubcategoryDto input)
        {
            return new Subcategory(input.Id, input.Name);
        }

        public static List<Subcategory> ToDomainModel(this IEnumerable<SubcategoryDto> input)
        {
            return input.Select(ToDomainModel).ToList();
        }
    }
}
