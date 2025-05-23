using PracticaBE.Models;


namespace PracticaBE.Services
{
    public class StudentService : IStudentService
    {
        // Mock data store for demonstration
        private List<Student> _students;

        public StudentService()
        {
            _students = new List<Student>
            {
                new Student { Id = 1, Name = "Alice", Nota = 60 },
                new Student { Id = 2, Name = "Bob", Nota = 22 }
            };
           
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            Student student = _students.FirstOrDefault(s => s.Id == id);
            return student;
        }

        public Student Create(Student student)
        {
            student.Id = _students.Count > 0 ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(student);
            return student;
        }

        public Student Update(int id, Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return null;

            student.Name = updatedStudent.Name;
            student.Nota = updatedStudent.Nota;
            return student;
        }

        public Student Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return null;

            _students.Remove(student);
            return student;
        }
        
        public Boolean HasApproved(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return false;

            return student.Nota >= 51;
        }
    }
}