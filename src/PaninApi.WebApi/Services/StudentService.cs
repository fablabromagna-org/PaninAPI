using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaninApi.Abstractions.Models;
using PaninApi.Abstractions.Services;

namespace PaninApi.WebApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly PaninApiDbContext _dbContext;

        public StudentService(PaninApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> GetOrCreateAsync(string id, School school)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (school is null)
            {
                throw new ArgumentNullException(nameof(school));
            }

            var student = await _dbContext.Students.Include(_ => _.Orders)
                .FirstOrDefaultAsync(_ => _.Id == id && _.School.Id == school.Id)
                .ConfigureAwait(false);

            if (student is null)
            {
                student = new Student
                {
                    School = school,
                    Id = id
                };

                await _dbContext.AddAsync(student);
                await _dbContext.SaveChangesAsync();
            }

            return student;
        }

        public async Task SetStudentClassAsync(Student student, StudentClass studentClass)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (studentClass is null)
            {
                throw new ArgumentNullException(nameof(studentClass));
            }
            
            student.StudentClass = studentClass;

            _dbContext.Update(student);
            await _dbContext.SaveChangesAsync();
        }
    }
}