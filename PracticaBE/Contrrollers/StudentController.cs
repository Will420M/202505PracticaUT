using Microsoft.AspNetCore.Mvc;
using PracticaBE.Models;
using PracticaBE.Services;
using System.Collections.Generic;
using System.Linq;

namespace PracticaBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;
       
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public List <Student> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet("{ci}")]
        public Student GetByCi(int ci)
        {
           return _studentService.GetByCi(ci);
        }
        
         [HttpGet("/HasApproved/{ci}")]
        public Boolean EvaluateHasApproved(int ci)
        {
           return _studentService.HasApproved(ci);
        }

        [HttpPost]
        public Student Create(Student student)
        {
            return _studentService.Create(student);
        }

        [HttpPut("{ci}")]
        public Student Update(int ci, Student updatedStudent)
        {
            return _studentService.Update(ci, updatedStudent);
        }

        [HttpDelete("{ci}")]
        public Student Delete(int ci)
        {
            return _studentService.Delete(ci);
        }
    }
}