using System.Collections.Generic;
using System.Threading.Tasks;
using PracticaBE.Models;

namespace PracticaBE.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetByCi(int ci);
        Student Create(Student student);
        Student Update(int ci, Student student);
        Student Delete(int ci);
        Boolean HasApproved(int ci);
    }
}