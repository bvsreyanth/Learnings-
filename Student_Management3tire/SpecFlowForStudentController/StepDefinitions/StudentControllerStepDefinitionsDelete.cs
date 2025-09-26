using Business_Layer.Service;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Student_Management.Controllers;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowForStudentController.StepDefinitions
{
    [Binding]
    public class StudentControllerStepDefinitionsDelete
    {
        private Mock<IStudentService> _studentServiceMock;
        private StudentController _studentController;
        private IActionResult _result;
        private int _studentIdToDelete;

        [BeforeScenario]
        public void Setup()
        {
            _studentServiceMock = new Mock<IStudentService>();
            _studentController = new StudentController(_studentServiceMock.Object, null); // Assuming you don't need IMapper for this scenario
        }

        [Given(@"A student with ID (\d+) exist")]
        public void GivenAStudentWithIDExist(int studentId)
        {
            _studentServiceMock.Setup(service => service.GetById(studentId)).Returns(new Student
            {
                StudentId = studentId,
                Name = "John",
                PhoneNumber = 12345670,
                EmailId = "john@example.com",
                CreatedTime = DateTime.UtcNow,
            });
            _studentIdToDelete = studentId;
        }

        [When(@"the client sends a request to delete the student with ID (\d+)")]
        public void WhenTheClientSendsARequestToDeleteTheStudentWithID(int studentId)
        {
            _result = _studentController.DeleteStudent(studentId);
        }

        [Then(@"the response should be successfull")]
        public void ThenTheResponseShouldBeSuccessful()
        {
            Assert.IsInstanceOf<OkObjectResult>(_result);
        }

        [Then(@"the response should indicate that the student is deleted")]
        public void ThenTheResponseShouldIndicateThatTheStudentIsDeleted()
        {
            var okObjectResult = (OkObjectResult)_result;
            Assert.AreEqual("Student Deleted", okObjectResult.Value);

            _studentServiceMock.Verify(service => service.Deletestd(It.IsAny<Student>()), Times.Once);
        }
    }
}
