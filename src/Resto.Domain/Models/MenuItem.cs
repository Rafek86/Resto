

namespace Resto.Domain.Models
{
    public class MenuItem : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } =true;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
      
        
        private MenuItem() { }

        public static MenuItem Create(string name, string description, decimal price, string category, bool isAvailable = true)
        {
            var menuItem = new MenuItem
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                IsAvailable = isAvailable
            };

            return menuItem;
        }


        public void Update(string name, string description, decimal price, string category, bool isAvailable)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            IsAvailable = isAvailable;
        }

        public void Delete()
        {
            IsAvailable = false;
        }

    }
}