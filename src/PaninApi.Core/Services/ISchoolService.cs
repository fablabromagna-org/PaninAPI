using System;
using System.Threading.Tasks;
using PaninApi.Core.Models;

namespace PaninApi.Core.Services
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

        /// <summary>
        /// Retrieves the student class from the 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Task<StudentClass> GetStudentClassAsync(Student student);
    }
}