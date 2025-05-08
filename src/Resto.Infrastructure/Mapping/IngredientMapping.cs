

namespace Resto.Infrastructure.Mapping
{
    public class IngredientMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Ingredient, IngredientDto>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Unit, src => src.Unit)
                .Map(dest => dest.RecordThreshold, src => src.RecordThreshold)
                .Map(dest => dest.IsAvailable, src => src.IsAvailable);
        }
    }
}
