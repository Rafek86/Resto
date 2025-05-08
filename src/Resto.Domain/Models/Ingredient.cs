

namespace Resto.Domain.Models
{
    public class Ingredient : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Unit { get; set; }
        public int RecordThreshold { get; set; }
        public bool IsAvailable { get; set; } = true;


        private Ingredient() { }

        public static Ingredient Create(string name, int unit, int recordThreshold)
        {
            var ingredient = new Ingredient
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Unit = unit,
                RecordThreshold = recordThreshold,
                IsAvailable = true
            };

            if (ingredient.Unit <= ingredient.RecordThreshold)
            {
                ingredient.AddDomainEvent(new IngredientLowStockEvent
                {
                    IngredientId = ingredient.Id,
                    Name = ingredient.Name,
                    Unit = ingredient.Unit
                });
            }

            return ingredient;
        }

        public void Update(string Name,int unit, int recordThreshold)
        {
            this.Name = Name;
            Unit = unit;
            RecordThreshold = recordThreshold;

            if (Unit <= RecordThreshold)
            {
                //AddDomainEvent(new IngredientLowStockEvent
                //{
                //    IngredientId = Id,
                //    Name = Name,
                //    Unit = Unit
                //});
            }
        }

        public void Delete()
        {
            IsAvailable = false;
        }

    }
}