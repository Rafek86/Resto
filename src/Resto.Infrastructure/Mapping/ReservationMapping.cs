namespace Resto.Infrastructure.Mapping
{
    public class ReservationMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Reservation, ReservationDto>()
                 .Map(dest => dest.CustomerName, src => src.Customer.Name)
                 .Map(dest => dest.TablesStatus, src => src.TablesStatus.ToString());
        }
    }
}
