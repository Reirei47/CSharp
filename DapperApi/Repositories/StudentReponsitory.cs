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
        public IEnumerable<StudentWithCourses> GetAllWithCourses()
        {
            var sql = @"
                SELECT s.Id, s.Name, c.Id, c.CourseName
                FROM Students s
                JOIN StudentCourses sc ON s.Id = sc.StudentId
                JOIN Courses c ON sc.CourseId = c.Id
                ORDER BY s.Id";

            using var db = NewConnection;

            var dict = new Dictionary<int, StudentWithCourses>();

            db.Query<StudentWithCourses, Course, StudentWithCourses>(
                sql,
                (student, course) =>
                {
                    if (!dict.TryGetValue(student.Id, out var existing))
                    {
                        existing = student;
                        dict[student.Id] = existing;
                    }
                    
                    if (course != null)
                    {
                        existing.Courses.Add(course);
                    }
                    
                    return existing;
                },
                splitOn: "Id" // Cột phân tách giữa Student và Course
            );

            return dict.Values;
        }
    }
    
   
}