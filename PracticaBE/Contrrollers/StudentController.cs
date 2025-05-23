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

        [HttpGet("{id}")]
        public Student GetById(int id)
        {
           return _studentService.GetById(id);
        }
        
         [HttpGet("/HasApproved/{id}")]
        public Boolean EvaluateHasApproved(int id)
        {
           return _studentService.HasApproved(id);
        }

        [HttpPost]
        public Student Create(Student student)
        {
            return _studentService.Create(student);
        }

        [HttpPut("{id}")]
        public Student Update(int id, Student updatedStudent)
        {
            return _studentService.Update(id, updatedStudent);
        }

        [HttpDelete("{id}")]
        public Student Delete(int id)
        {
            return _studentService.Delete(id);
        }
    }
}