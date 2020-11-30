using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PaninApi.Abstractions.Dtos;
using PaninApi.Abstractions.Dtos.MeDtos;
using PaninApi.Abstractions.Enums;
using PaninApi.Abstractions.Models;

namespace PaninApi.WebApi.Automapper
{
    public class InProgressOrdersResolver : IValueResolver<Student, StudentMeDto, IEnumerable<BasicOrderDto>>
    {
        public IEnumerable<BasicOrderDto> Resolve(Student source, StudentMeDto destination,
            IEnumerable<BasicOrderDto> destMember, ResolutionContext context)
        {
            return context.Mapper.Map<IEnumerable<BasicOrderDto>>(source.Orders.Where(o =>
                o.Status != OrderStatus.Expired && o.Status != OrderStatus.Ready && o.Status != OrderStatus.Rejected));
        }
    }
}