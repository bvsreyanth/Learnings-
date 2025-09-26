using Business_Layer.DTO;
using Business_Layer.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Student_Management.Controllers;

namespace SpecFlowForStudentController.StepDefinitions
{
    [Binding]
    public class StudentControllerStepDefinitionsPost
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

        [Given(@"a student with the following details:")]
        public void GivenAStudentWithTheFollowingDetails(Table table)
        {
            var studentDetails = table.Rows[0];
            var student = new CreateDTO
            {
                Name = studentDetails["Name"],
                PhoneNumber = int.Parse(studentDetails["PhoneNumber"]),
                EmailId = studentDetails["EmailId"],
            };

            _studentServiceMock.Setup(service => service.CreateStudents(It.IsAny<CreateDTO>()));

        }

        [When(@"the client sends a request to create the student with details:")]
        public void WhenTheClientSendsARequestToCreateTheStudentWithDetails(Table table)
        {
            var studentDetails = table.Rows[0];
            var studentRequest = new CreateDTO
            {
                Name = studentDetails["Name"],
                PhoneNumber = int.Parse(studentDetails["PhoneNumber"]),
                EmailId = studentDetails["EmailId"],
            };
            _result = _studentController.CreateStudent(studentRequest);
        }

        [Then(@"the response should indicate successful creation")]
        public void ThenTheResponseShouldIndicateSuccessfulCreation()
        {
            Assert.IsInstanceOf<OkObjectResult>(_result);
            var okObjectResult = (OkObjectResult)_result;
            Assert.AreEqual("Sudent created successfully", okObjectResult.Value);
        }
    }
}
