namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DTO;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierDto, Supplier>();
            this.CreateMap<PartDto, Part>();
            this.CreateMap<CustomerDto, Customer>();
            this.CreateMap<SaleDto, Sale>();
        }
    }
}
