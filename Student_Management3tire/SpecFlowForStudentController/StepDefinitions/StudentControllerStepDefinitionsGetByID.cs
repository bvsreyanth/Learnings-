using Business_Layer.Service;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Student_Management.Controllers;

namespace SpecFlowForStudentController.StepDefinitions
{
    [Binding]
    public class StudentControllerStepDefinitionsGetByID
    {
        private Mock<IStudentService> _studentServiceMock;
        private StudentController _studentController;
        private IActionResult _result;

        [BeforeScenario]
        public void Setup()
        {
            _studentServiceMock = new Mock<IStudentService>();
            _studentController = new StudentController(_studentServiceMock.Object, null);
        }

        [Given(@"a student with ID (\d+) exists")]
        public void GivenAStudentWithIDExists(int studentId)
        {
            _studentServiceMock.Setup(service => service.GetById(studentId)).Returns(new Student
            {
                StudentId = studentId,
                Name = "John",
                PhoneNumber = 12345670,
                EmailId = "john@example.com",
                CreatedTime = DateTime.UtcNow,
            });
        }

        [When(@"the client sends a request to get the student with ID (\d+)")]
        public void WhenTheClientSendsARequestToGetTheStudentWithID(int studentId)
        {
            _result = _studentController.GetByIdDetails(studentId);
        }

        [Then(@"the response should be successful")]
        public void ThenTheResponseShouldBeSuccessful()
        {
            Assert.IsInstanceOf<OkObjectResult>(_result);
        }

        [Then(@"the response should contain the details of the student with ID (\d+)")]
        public void ThenTheResponseShouldContainTheDetailsOfTheStudentWithID(int studentId)
        {
            var okObjectResult = (OkObjectResult)_result;
            var student = (Student)okObjectResult.Value;

            Assert.AreEqual(studentId, student.StudentId);
        }
    }
}
