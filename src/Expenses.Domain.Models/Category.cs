﻿using System.Collections.Generic;

namespace Expenses.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subcategory> Subcategories { get; set; }

    }
}
