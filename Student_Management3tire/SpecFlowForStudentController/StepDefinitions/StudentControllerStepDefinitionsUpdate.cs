//using Business_Layer.DTO;
//using Business_Layer.Service;
//using Data_Access_Layer.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Moq;
//using NUnit.Framework;
//using Student_Management.Controllers;
//using System;
//using System.Collections.Generic;
//using TechTalk.SpecFlow;

//namespace SpecFlowForStudentController.StepDefinitions
//{
//    [Binding]
//    public class StudentControllerStepDefinitionsUpdate
//    {
//        private Mock<IStudentService> _studentServiceMock;
//        private StudentController _studentController;
//        private IActionResult _result;
//        private int _studentIdToUpdate;

//        [BeforeScenario]
//        public void Setup()
//        {
//            _studentServiceMock = new Mock<IStudentService>();
//            _studentController = new StudentController(_studentServiceMock.Object, null);
//        }
       
//        [Given(@"a student with ID (\d+) exists in list of students")]
//        public void GivenAStudentWithIDExistsinlistofstudents(int studentId)
//        {
//            _studentServiceMock.Setup(service => service.GetById(studentId)).Returns(new Student
//            {
//                StudentId = studentId,
//                Name = "John",
//                PhoneNumber = 12345670,
//                EmailId = "john@example.com",
//                CreatedTime = DateTime.UtcNow,
//            });
//            _studentIdToUpdate = studentId;
//        }

//        [When(@"the client sends a request to update the student with ID (.*) and the following details:")]
//        public void WhenTheClientSendsARequestToUpdateTheStudentWithIDAndTheFollowingDetails(int studentId, TechTalk.SpecFlow.Table table)
//        {
//            try
//            {
//                var studentDetails = table.Rows[0];
//                var updateDTO = new UpdateDTO
//                {
//                    StudentId = studentId,
//                    Name = studentDetails["Name"],
//                    PhoneNumber = int.Parse(studentDetails["PhoneNumber"]),
//                    EmailId = studentDetails["EmailId"],
//                };

//                // Invoke the actual controller action and store the result
//                _result = _studentController.UpdateStudent(studentId, updateDTO);

//                // Print the result for debugging purposes
//                Console.WriteLine($"_result: {_result}");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Exception: {ex.Message}");
//                throw;  // Rethrow the exception to fail the test
//            }
//        }

//        [Then(@"the response should contain the updated student details:")]
//        public void ThenTheResponseShouldContainTheUpdatedStudentDetails(TechTalk.SpecFlow.Table table)
//        {
//            var okObjectResult = (OkObjectResult)_result;
//            var updatedStudent = (Student)okObjectResult.Value;
//            var expectedDetails = table.Rows[0];
//            Assert.AreEqual(expectedDetails["Name"], updatedStudent.Name);
//            Assert.AreEqual(int.Parse(expectedDetails["PhoneNumber"]), updatedStudent.PhoneNumber);
//            Assert.AreEqual(expectedDetails["EmailId"], updatedStudent.EmailId);
//        }
//    }
//}
