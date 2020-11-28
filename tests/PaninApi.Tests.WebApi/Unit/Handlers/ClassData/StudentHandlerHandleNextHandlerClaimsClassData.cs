using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using PaninApi.WebApi.Consts;

namespace PaninApi.Tests.WebApi.Unit.Handlers.ClassData
{
    public class StudentHandlerHandleNextHandlerClaimsClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Claim[]
                {
                }
            };

            yield return new object[]
            {
                new Claim[]
                {
                    new Claim(CustomClaims.GSuiteOrg, " "),
                }
            };

            yield return new object[]
            {
                new Claim[]
                {
                    new Claim(CustomClaims.GSuiteOrg, String.Empty),
                }
            };

            yield return new object[]
            {
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, " "),
                }
            };

            yield return new object[]
            {
                new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, String.Empty),
                }
            };

            yield return new object[]
            {
                new Claim[]
                {
                    new Claim(CustomClaims.GSuiteOrg, String.Empty),
                    new Claim(ClaimTypes.NameIdentifier, String.Empty),
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Claims
    {
    }
}