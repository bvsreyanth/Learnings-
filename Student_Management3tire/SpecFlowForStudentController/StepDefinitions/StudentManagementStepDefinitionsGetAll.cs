using AutoMapper;
using Business_Layer.Service;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Student_Management.Controllers;

namespace SpecFlowForStudentController.StepDefinitions
{
    [Binding]
    public class StudentManagementStepDefinitionsGetAll
    {
        private Mock<IStudentService> _studentServiceMock;
        private Mock<IMapper> _mapperMock;
        private StudentController _studentController;
        private IActionResult _result;

        [BeforeScenario]
        public void Setup()
        {
            _studentServiceMock = new Mock<IStudentService>();
            _mapperMock = new Mock<IMapper>();
            _studentController = new StudentController(_studentServiceMock.Object, _mapperMock.Object);
        }

        [Given(@"the StudentService returns a list of students")]
        public void GivenTheStudentServiceReturnsAListOfStudents()
        {
            _studentServiceMock.Setup(service => service.GetAll()).Returns(new List<Student>
            {
                 new Student { StudentId = 1, Name = "John", PhoneNumber = 12345670, EmailId = "john@example.com", CreatedTime = DateTime.UtcNow},
                 new Student { StudentId = 2, Name = "Jane", PhoneNumber = 98765432, EmailId = "jane@example.com", CreatedTime = DateTime.UtcNow },
            });
        }

        [When(@"the client sends a request to get all students")]
        public void WhenTheClientSendsARequestToGetAllStudents()
        {
            _result = _studentController.GetStudents();
        }

        [Then(@"a list of students should be returned")]
        public void ThenAListOfStudentsShouldBeReturned()
        {
            Assert.IsInstanceOf<OkObjectResult>(_result);
            var okObjectResult = (OkObjectResult)_result;
            var students = (List<Student>)okObjectResult.Value;
            Assert.IsNotNull(students);
        }
    }
}

