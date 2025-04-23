using Dapper;
using Npgsql;
using PAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private PostgreSQLConfiguration _connectionString;
        public StudentRepository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        //CONEXION DB  
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConectionString);
        }

        public async Task<bool> DeleteStudent(Student student)
        {
            var db = dbConnection();
            var sql = @"  
                               DELETE FROM public.""Students""   
                               WHERE id = @Id ";

            var result = await db.ExecuteAsync(sql, new { Id = student.Id });
            return result > 0;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var db = dbConnection();
            var sql = @"  
                               SELECT id, name, career  
                               FROM public.""Students"" ";
            return await db.QueryAsync<Student>(sql, new { });
        }

        public async Task<Student> GetStudentDetails(int id)
        {
            var db = dbConnection();
            var sql = @"  
                               SELECT id, name, career  
                               FROM public.""Students""   
                                   WHERE id = @Id ";
            return await db.QueryFirstOrDefaultAsync<Student>(sql, new { Id = id });
        }

        // Fix for CS0535: Implementing the missing method from the interface  
        public async Task<Student> GetStudentDetails(Student student)
        {
            var db = dbConnection();
            var sql = @"  
                               SELECT id, name, career  
                               FROM public.""Students""   
                                   WHERE id = @Id ";
            return await db.QueryFirstOrDefaultAsync<Student>(sql, new { Id = student.Id });
        }

        public async Task<bool> InsertStudent(Student student)
        {
            var db = dbConnection();
            var sql = @"  
                               INSERT INTO public.""Students"" (name, career)  
                               VALUES(@name, @career) ";
            var result = await db.ExecuteAsync(sql, new { student.Name, student.Career });
            return result > 0;
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            var db = dbConnection();
            var sql = @"  
                               UPDATE public.""Students""  
                               SET name = @name, career = @career  
                               WHERE id = @id ";

            var result = await db.ExecuteAsync(sql, new {student.Id, student.Name, student.Career });
            return result > 0;
        }
    }
}
