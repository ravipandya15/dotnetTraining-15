using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6WebApi.Models
{
    public class StudentService : IStudentService
    {
        private readonly StudentDataContext _context;
        public StudentService(StudentDataContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students;
        }
        public Student GetOneStudent(int id)
        {
            return _context.Students.SingleOrDefault(s => s.Sid == id);
        }
    }
}
