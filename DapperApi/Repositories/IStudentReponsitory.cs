using DapperApi.Models;
namespace DapperApi.Repositories;

    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student? GetbyId(int id);
        void Create(Student student);
        void Update(Student student);
        void Delete(int id);
        
    }
