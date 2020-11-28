using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;

namespace PaninApi.Tests.WebApi.Unit.Handlers.ClassData
{
    public class BarmanHandlerHandlerClaimsClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Claim[] { }
            };

            yield return new object[]
            {
                new[] {new Claim(ClaimTypes.NameIdentifier, String.Empty)}
            };

            yield return new object[]
            {
                new[] {new Claim(ClaimTypes.NameIdentifier, "  ")}
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}