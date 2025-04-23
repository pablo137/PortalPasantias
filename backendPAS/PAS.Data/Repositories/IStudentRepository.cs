using PAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Data.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentDetails(int id);
        Task<bool> InsertStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(Student student);
    }
}
