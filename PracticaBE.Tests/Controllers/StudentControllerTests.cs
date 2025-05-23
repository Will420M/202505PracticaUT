using PracticaBE.Controllers;
using PracticaBE.Services;
using Moq;



namespace PracticaBE.Tests
{
    public class StudentControllerTests
    {
        [Fact]
        public void Student_withValidIdandOver51Nota_IsApproved()
        {
            // Arrange
            
            var studentService = new Mock<IStudentService>();
            StudentController studentController = new StudentController(studentService.Object);
            //var student = new Student { Id = 1, Name = "Alice", Nota = 60 };
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
    }

}

