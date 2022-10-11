using System.Collections.Generic;

namespace Expenses.Domain.Models
{
    public class Category
    {
        public uint Id { get; }
        public string Name { get; }
        public List<Subcategory> Subcategories { get; }

        public Category(uint id, string name, List<Subcategory> subcategories)
        {
            Id = id;
            Name = name;
            Subcategories = subcategories;
        }

    }
}
