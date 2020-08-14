using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartStructures.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;

        public MockStudentRepository()
        {
            if (_studentList == null)
            {
                _studentList = new List<Student>()
            {
                new Student() { Id = 1, Name = "Surya", Email = "surya@gmail.com", Standard="10th" },
                new Student() { Id = 2, Name = "Ram", Email = "ram@gmail.com", Standard="5th " },
                new Student() { Id = 3, Name = "Krishna",  Email = "krishna@gmail.com", Standard="6th " },
                new Student() { Id = 3, Name = "Rao",  Email = "rao@gmail.com", Standard="7th Standard" },
            };
            }
        }

        public Student Add(Student student)
        {
            student.Id = _studentList.Max(e => e.Id) + 1;
            _studentList.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
            Student Student = _studentList.FirstOrDefault(e => e.Id == id);
            if (Student != null)
            {
                _studentList.Remove(Student);
            }
            return Student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }

        public Student GetStudent(int Id)
        {
            return _studentList.FirstOrDefault(e => e.Id == Id);
        }


        public Student Update(Student studentChanges)
        {
            Student student = _studentList.FirstOrDefault(e => e.Id == studentChanges.Id);
            if (student != null)
            {
                student.Name = studentChanges.Name;
                student.Email = studentChanges.Email;
                student.Standard = studentChanges.Standard;                
            }
            return student;
        }
    }
}
