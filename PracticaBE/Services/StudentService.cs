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
                new Student { Ci = 123, Name = "Carlos", Nota = 60 },
                new Student { Ci = 221, Name = "Fernando", Nota = 22 }
            };
           
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student GetByCi(int ci)
        {
            Student student = _students.FirstOrDefault(s => s.Ci == ci);
            return student;
        }

        public Student Create(Student student)
        {
            student.Ci = _students.Count > 0 ? _students.Max(s => s.Ci) + 1 : 1;
            _students.Add(student);
            return student;
        }

        public Student Update(int ci, Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.Ci == ci);
            if (student == null)
                return null;

            student.Name = updatedStudent.Name;
            student.Nota = updatedStudent.Nota;
            return student;
        }

        public Student Delete(int ci)
        {
            var student = _students.FirstOrDefault(s => s.Ci == ci);
            if (student == null)
                return null;

            _students.Remove(student);
            return student;
        }
        
        public Boolean HasApproved(int ci)
        {
            var student = _students.FirstOrDefault(s => s.Ci == ci);
            if (student == null)
                return false;

            return student.Nota >= 51;
        }
    }
}