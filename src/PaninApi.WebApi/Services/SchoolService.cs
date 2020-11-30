using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaninApi.Abstractions.Models;
using PaninApi.Abstractions.Services;

namespace PaninApi.WebApi.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly PaninApiDbContext _dbContext;

        public SchoolService(PaninApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<School> GetSchoolFromStudentOrgAsync(string gSuiteOrganization)
        {
            return await _dbContext.Schools.Include(_ => _.CoffeeShops).FirstOrDefaultAsync(school => school.Tenant == gSuiteOrganization);
        }
    }
}