namespace Expenses.Domain.Models
{
    public class Subcategory
    {
        public uint Id { get; }
        public string Name { get; }

        public Subcategory(uint id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
