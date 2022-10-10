using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expenses.Infrastructure.Models
{
    public class CategoryDto
    {     
        [Key]
        public uint Id { get; set; }
        public string Name { get; set; }
        public List<SubcategoryDto> Subcategories { get; set; }
       
    }
}
