using AutoMapper;
using PaninApi.Abstractions.Dtos;
using PaninApi.Abstractions.Dtos.MeDtos;
using PaninApi.Abstractions.Models;
using PaninApi.WebApi.Automapper;

namespace PaninApi.WebApi
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BaseUser, MeDto>().IncludeAllDerived();
            CreateMap<Student, StudentMeDto>()
                .ForMember(_ => _.InProgressOrders, m => m.MapFrom<InProgressOrdersResolver>())
                .ForMember(_ => _.CoffeeShops, m => m.MapFrom<CoffeeShopsResolver>());
            CreateMap<Barman, BarmanMeDto>();

            CreateMap<Order, BasicOrderDto>();
            CreateMap<StudentClass, StudentClassDto>();
        }
    }
}