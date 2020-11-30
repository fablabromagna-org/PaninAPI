using System.Threading.Tasks;
using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Student> GetOrCreateAsync(string id, School school);
        
        Task SetStudentClassAsync(Student student, StudentClass studentClass);
    }
}