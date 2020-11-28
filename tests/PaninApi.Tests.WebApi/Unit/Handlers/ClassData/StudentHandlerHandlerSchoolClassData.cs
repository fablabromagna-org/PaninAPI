using System.Collections;
using System.Collections.Generic;
using PaninApi.Abstractions.Models;

namespace PaninApi.Tests.WebApi.Unit.Handlers.ClassData
{
    public class StudentHandlerHandlerSchoolClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new School()
            };
            
            yield return new object[]
            {
                null
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}