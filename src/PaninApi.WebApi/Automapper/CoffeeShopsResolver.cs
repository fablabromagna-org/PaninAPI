using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PaninApi.Abstractions.Dtos.MeDtos;
using PaninApi.Abstractions.Models;

namespace PaninApi.WebApi.Automapper
{
    public class CoffeeShopsResolver : IValueResolver<Student, StudentMeDto, IEnumerable<int>>
    {
        public IEnumerable<int> Resolve(Student source, StudentMeDto destination, IEnumerable<int> destMember,
            ResolutionContext context)
        {
            return source.School.CoffeeShops.Select(_ => _.Id).ToArray();
        }
    }
}