using System.Collections.Generic;
using AutoMapper;
using PaninApi.Abstractions.Dtos;
using PaninApi.Abstractions.Dtos.MeDtos;
using PaninApi.Abstractions.Enums;
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

            CreateMap<ItemModifier, IEnumerable<string>>().ConvertUsing<ItemModifierMapper>();
            CreateMap<Item, ItemDto>();
            CreateMap<Order, BasicOrderDto>();
            CreateMap<StudentClass, StudentClassDto>();
            CreateMap<InputStudentClassDto, StudentClass>();
            CreateMap<CoffeeShop, CoffeeShopDto>();
        }
    }
}