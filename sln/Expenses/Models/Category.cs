namespace Expenses.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public Category(string value)
        {
            Value = value;
        }
    }
}
