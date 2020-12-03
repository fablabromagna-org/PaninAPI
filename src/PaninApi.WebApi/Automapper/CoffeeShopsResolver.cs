using System.Collections.Generic;
using AutoMapper;
using PaninApi.Abstractions.Dtos;
using PaninApi.Abstractions.Dtos.MeDtos;
using PaninApi.Abstractions.Models;

namespace PaninApi.WebApi.Automapper
{
    public class CoffeeShopsResolver : IValueResolver<Student, StudentMeDto, IEnumerable<CoffeeShopDto>>
    {
        public IEnumerable<CoffeeShopDto> Resolve(Student source, StudentMeDto destination,
            IEnumerable<CoffeeShopDto> destMember, ResolutionContext context)
        {
            return context.Mapper.Map<IEnumerable<CoffeeShopDto>>(source.School.CoffeeShops);
        }
    }
}