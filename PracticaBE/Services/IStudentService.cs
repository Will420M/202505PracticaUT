using System.Collections.Generic;
using System.Threading.Tasks;
using PracticaBE.Models;

namespace PracticaBE.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        Student Create(Student student);
        Student Update(int id, Student student);
        Student Delete(int id);
        Boolean HasApproved(int id);
    }
}