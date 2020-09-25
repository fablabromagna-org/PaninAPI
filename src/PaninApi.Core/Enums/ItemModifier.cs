using System;

namespace PaninApi.Core.Enums
{
    [Flags]
    public enum ItemModifier
    {
        Vegan = 1,
        Bio = 2,
        LactoseFree = 4,
        GlutenFree = 6
    }
}