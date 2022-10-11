using System.ComponentModel.DataAnnotations;

namespace Expenses.Infrastructure.Models
{
    public class SubcategoryDto
    {
        [Key]
        public uint Id { get; set; }
        public string Name { get; set; }

        public uint CategoryId { get; set; }

    }
}
