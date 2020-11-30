using System;
using System.Threading.Tasks;
using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Services
{
    public interface ISchoolService
    {
        /// <summary>
        /// Retrieves user's school, if is supported.
        /// </summary>
        /// <param name="gSuiteOrganization">GSuite principal domain (hd claim).</param>
        /// <returns>Student's school if supported, null otherwise.</returns>
        /// <exception cref="ArgumentNullException">When <paramref name="gSuiteOrganization"/> is null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="gSuiteOrganization"/> is invalid.</exception>
        Task<School> GetSchoolFromStudentOrgAsync(string gSuiteOrganization);
    }
}