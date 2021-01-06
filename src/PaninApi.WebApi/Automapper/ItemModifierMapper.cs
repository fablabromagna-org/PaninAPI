using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PaninApi.Abstractions.Enums;

namespace PaninApi.WebApi.Automapper
{
    public class ItemModifierMapper : ITypeConverter<ItemModifier, IEnumerable<string>>
    {
        public IEnumerable<string> Convert(ItemModifier source, IEnumerable<string> destination, ResolutionContext context)
        {
            var flags = Enum.GetValues(typeof(ItemModifier)).Cast<ItemModifier>()
                .Where(f => source.HasFlag(f)).Select(f => f.ToString());

            return flags;
        }
    }
}