using PracticaBE.Controllers;
using PracticaBE.Services;
using PracticaBE.Models;
using Xunit;
using Moq;



namespace PracticaBE.Tests
{
    public class StudentControllerTests
    {
        private readonly Mock<IStudentService> _mockService;
        private readonly StudentController _controller;
        public StudentControllerTests()
        {
            _mockService = new Mock<IStudentService>();
            _controller = new StudentController(_mockService.Object);
        }
        [Fact]
        public void Student_withValidCiAndOver51Nota_IsApproved()
        {
            // Arrange

            var studentService = new Mock<IStudentService>();
            StudentController studentController = new StudentController(studentService.Object);
            //var student = new Student { Ci = 1, Name = "Alice", Nota = 60 };
            studentService.Setup(s => s.HasApproved(1)).Returns(
                true
            );

            /*StudentService studentService = new StudentService();
            StudentController studentController = new StudentController(studentService);
            */
            // Act
            Boolean result = studentController.EvaluateHasApproved(1);
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasApproved_ShouldFail_WithSpecialNicknameAndMinNota()
        {
        // Arrange
        var service = new StudentService();
        var student = new Student 
        { 
            Ci = 1012,                 
            Name = "C4los D9",      
            Nota = 50                
        };

        // Act
        bool result = service.HasApproved(student.Ci);

        // Assert
        Assert.False(result); 
        Assert.Equal(1012, student.Ci);
        Assert.Equal("C4los D9", student.Name);
        }

        [Fact]
        public void Create_WithValidStudent_ReturnsCreatedStudent()
        {
            // Arrange
            var newStudent = new Student { Ci = 2, Name = "Fernando", Nota = 90 };
            _mockService.Setup(s => s.Create(newStudent)).Returns(newStudent);

            // Act
            var result = _controller.Create(newStudent);

            // Assert
            Assert.Equal(newStudent, result);
        }

        [Fact]
        public void GetById_WithValidId_ReturnsStudent()
        {
            // Arrange
            var expectedStudent = new Student { Ci = 1, Name = "C4los D9", Nota = 80 };
            _mockService.Setup(s => s.GetByCi(1)).Returns(expectedStudent);

            // Act
            var result = _controller.GetByCi(1);

            // Assert
            Assert.Equal(expectedStudent, result);
        }

        [Fact]
        public void Create_Student_ReturnsCreatedStudent()
        {
            // Arrange
            var newStudent = new Student { Ci = 2, Name = "Fernando", Nota = 90 };
            _mockService.Setup(s => s.Create(newStudent)).Returns(newStudent);

            // Act
            var result = _controller.Create(newStudent);

            // Assert
            Assert.Equal(newStudent, result);
        }
    }

}

