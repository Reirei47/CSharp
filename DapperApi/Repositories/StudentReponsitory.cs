using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DapperApi.Models;

namespace DapperApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connStr;

        public StudentRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection")!;
        }
    
        private IDbConnection NewConnection => new MySqlConnection(_connStr);

        public IEnumerable<Student> GetAll()
        {
            using (var dbConnection = NewConnection)
            {
                dbConnection.Open();
                return dbConnection.Query<Student>("SELECT * FROM Students");
            }
        }

        public Student? GetbyId(int id)
        {
            using (var dbConnection = NewConnection)
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<Student>("SELECT * FROM Students WHERE Id = @Id", new { Id = id });
            }
        }

        public void Create(Student student)
        {
            using (var dbConnection = NewConnection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Students (Name, Age, Email) VALUES (@Name, @Age, @Email)", student);
            }
        }

        public void Update(Student student)
        {
            using (var dbConnection = NewConnection)
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Students SET Name = @Name, Age = @Age, Email = @Email WHERE Id = @Id", student);
            }
        }

        public void Delete(int id)
        {
            using (var dbConnection = NewConnection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Students WHERE Id = @Id", new { Id = id });
            }
        }
    }
}