using AutoMapper;
using Business_Layer.DTO;
using Business_Layer.Service;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repositorys;
using Moq;

namespace StudentMnaagementTest.Tests
{
    [TestFixture]
    public class StudentServiceTests
    {
        private readonly StudentService _studentService;
        private readonly Mock<IStudentRepository> _studentRepositoryMock = new Mock<IStudentRepository>();
        private readonly Mock<IMapper> _mapper = new Mock<IMapper>();
        private List<Student> _students;
        public StudentServiceTests()
        {
            _studentService = new StudentService(_studentRepositoryMock.Object,_mapper.Object);

            _students = new List<Student> {
                new Student {
                    StudentId = 1,
                    Name = "Test",
                    EmailId = "test@gmail.com",
                    PhoneNumber = 3453454,
                    CreatedTime = new DateTime(2023, 12, 31)
                },
            };
        }

        [Test]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            _studentRepositoryMock.Setup(x => x.getalldetails()).Returns(_students);
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);
            var result = studentService.GetAll();
            Assert.NotNull(result);
            Assert.AreEqual(_students.Count, result.Count);
        }

        [Test]
        //Test fails
        public void GetAllStudents_ShouldReturnNull()
        {
            _studentRepositoryMock.Setup(x => x.getalldetails()).Returns((List<Student>)null); // Return null
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);
            var result = studentService.GetAll();//Value cannot be null. 
            Assert.Null(result);
        }
        [Test]
        public void GetAllStudents_ShouldReturnDifferentCount()
        {
            // Setup repository to return a list with a different count of students
            var differentStudents = new List<Student> {
              new Student { StudentId = 1, Name = "Test" },
              new Student { StudentId = 2, Name = "Admin" }
    };
            _studentRepositoryMock.Setup(x => x.getalldetails()).Returns(differentStudents);
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);
            var result = studentService.GetAll();
            Assert.NotNull(result);
            Assert.AreEqual(differentStudents.Count, result.Count);
        }

        [Test]
        public void GetAllStudents_ShouldReturnEmptyList()
        {
            _studentRepositoryMock.Setup(x => x.getalldetails()).Returns(new List<Student>()); 
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);
            var result = studentService.GetAll();
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void GetByIdStudents_ShouldReturn_WhenStudentExists()
        {
            // Arrange
            int expectedStudentId = 1;
            var expectedStudent = _students.FirstOrDefault(s => s.StudentId == expectedStudentId);

            _studentRepositoryMock.Setup(x => x.GetByIdDetails(It.IsAny<int>())).Returns((int id) =>
            {
                var result = _students.FirstOrDefault(x => x.StudentId == id);
                return result;
            });

            // Act
            var actualStudent = _studentService.GetById(expectedStudentId);
            Assert.IsNotNull(actualStudent);
            Assert.AreEqual(expectedStudentId, actualStudent.StudentId);
          
        }
        [Test]
        public void GetByIdStudents_ShouldReturnNull_WhenStudentDoesNotExist()
        {
            // Arrange
            int nonExistentStudentId = 999; //  ID does not exist 
            _studentRepositoryMock.Setup(x => x.GetByIdDetails(It.IsAny<int>())).Returns((int id) =>
            {
                var result = _students.FirstOrDefault(x => x.StudentId == id);
                return result;
            });

            // Act
            var actualStudent = _studentService.GetById(nonExistentStudentId);

            // Assert
            Assert.IsNull(actualStudent);
        }
        [Test]
        //Test Fails
        public void GetByIdStudents_ShouldReturnNull_WhenInvalidStudentId()
        {
            // Arrange
            int invalidStudentId = -1; // invalid ID
            _studentRepositoryMock.Setup(x => x.GetByIdDetails(It.IsAny<int>())).Returns((int id) =>
            {
                var result = _students.FirstOrDefault(x => x.StudentId == id);
                return result;
            });

            // Act
            var actualStudent = _studentService.GetById(invalidStudentId);

            // Assert
            Assert.IsNull(actualStudent);
        }
        [Test]
        //Test Fails
        public void GetByIdStudents_ShouldReturnNull_WhenUsingMaxStudentId()
        {
            // Arrange
            int maxStudentId = int.MaxValue; // Maximum allowed student ID
            _studentRepositoryMock.Setup(x => x.GetByIdDetails(It.IsAny<int>())).Returns((int id) =>
            {
                var result = _students.FirstOrDefault(x => x.StudentId == id);
                return result;
            });

            // Act
            var actualStudent = _studentService.GetById(maxStudentId);

            // Assert
            Assert.IsNull(actualStudent);
        }
        [Test]
        //Test Fails
        public void GetByIdStudents_ShouldReturnStudent_WhenUsingMaxStudentId()
        {
            // Arrange
            int maxStudentId = int.MaxValue; // Maximum integer value 
            var expectedStudent = _students.FirstOrDefault(s => s.StudentId == maxStudentId);

            _studentRepositoryMock.Setup(x => x.GetByIdDetails(It.IsAny<int>())).Returns((int id) =>
            {
                var result = _students.FirstOrDefault(x => x.StudentId == id);
                return result;
            });

            // Act
            var actualStudent = _studentService.GetById(maxStudentId);

            // Assert
            Assert.IsNotNull(actualStudent);
            Assert.AreEqual(expectedStudent.StudentId, actualStudent.StudentId);
        }


        [Test]
        public void AddStudent_ShouldReturnNewStudent()
        {
          
            _studentRepositoryMock.Setup(x => x.AddStudent(It.IsAny<Student>())).Callback<Student>(student =>
            {
                _students.Add(student);
            });
            var newStudent = new CreateDTO
            {
                Name = "New Student",
                EmailId = "newstudent@gmail.com",
                PhoneNumber = 1234567,
            };
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);

            var result = studentService.CreateStudents(newStudent);
           
            Assert.IsTrue(_students.Contains(result));
        }
        [Test]
        //Test Fails
        public void AddStudent_ShouldNotAddNullStudent()
        {
            // Arrange
            CreateDTO newStudent = null; // Null input

            _studentRepositoryMock.Setup(x => x.AddStudent(It.IsAny<Student>())).Callback<Student>(student =>
            {
                _students.Add(student);
            });
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);

            // Act
            var result = studentService.CreateStudents(newStudent);

            // Assert
            Assert.AreEqual(0, _students.Count);
        }
        [Test]
        //Test Fails
        public void AddStudent_ShouldNotAddExistingStudent()
        {
            var existingStudent = new Student
            {
                Name = "New Student",
                EmailId = "newstudent@gmail.com",
                PhoneNumber = 1234567,
            };
            _students.Add(existingStudent);

            _studentRepositoryMock.Setup(x => x.AddStudent(It.IsAny<Student>())).Callback<Student>(student =>
            {
                _students.Add(student);
            });
            var newStudent = new CreateDTO
            {
                Name = "New Student",
                EmailId = "newstudent@gmail.com",
                PhoneNumber = 1234567,
            };
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);

            // Act
            var result = studentService.CreateStudents(newStudent);

            // Assert
            Assert.IsFalse(_students.Count(st => st.EmailId == newStudent.EmailId) > 1); 
        }
        [Test]
        public void AddStudent_ShouldSuccessfullyAddMultipleStudents()
        {
            // Arrange
            var newStudent1 = new CreateDTO
            {
                Name = "New Student 1",
                EmailId = "newstudent1@gmail.com",
                PhoneNumber = 1234567,
            };

            var newStudent2 = new CreateDTO
            {
                Name = "New Student 2",
                EmailId = "newstudent2@gmail.com",
                PhoneNumber = 9876543,
            };

            _studentRepositoryMock.Setup(x => x.AddStudent(It.IsAny<Student>())).Callback<Student>(student =>
            {
                _students.Add(student);
            });
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);

            // Act
            var result1 = studentService.CreateStudents(newStudent1);
            var result2 = studentService.CreateStudents(newStudent2);

            // Assert
            Assert.IsTrue(_students.Contains(result1)); // student 1 was added
            Assert.IsTrue(_students.Contains(result2)); // student 2 was added 
        }
        [Test]
        public void AddStudent_ShouldSuccessfullyAddNewStudent()
        {
            // Arrange
            var newStudent = new CreateDTO
            {
                Name = "New Student",
                EmailId = "newstudent@gmail.com",
                PhoneNumber = 1234567,
            };

            _studentRepositoryMock.Setup(x => x.AddStudent(It.IsAny<Student>())).Callback<Student>(student =>
            {
                _students.Add(student);
            });
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);

            // Act
            var result = studentService.CreateStudents(newStudent);

            // Assert
            Assert.IsTrue(_students.Contains(result)); 
        }
        [Test]
        //Test Fails
        public void AddStudent_ShouldNotAddStudentWithEmptyName()
        {
            // Arrange
            var newStudent = new CreateDTO
            {
                Name = "", // Empty name
                EmailId = "emptyname@gmail.com",
                PhoneNumber = 1234567,
            };

            _studentRepositoryMock.Setup(x => x.AddStudent(It.IsAny<Student>())).Callback<Student>(student =>
            {
                _students.Add(student);
            });
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);

            // Act
            var result = studentService.CreateStudents(newStudent);

            // Assert
            Assert.IsFalse(_students.Contains(result));
        }
        [Test]
        //Test Fails
        public void AddStudent_ShouldNotAddStudentWithInvalidEmail()
        {
            // Arrange
            var newStudent = new CreateDTO
            {
                Name = "Invalid Email Student",
                EmailId = "invalid_email",
                PhoneNumber = 1234567,
            };

            _studentRepositoryMock.Setup(x => x.AddStudent(It.IsAny<Student>())).Callback<Student>(student =>
            {
                _students.Add(student);
            });
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);

            // Act
            var result = studentService.CreateStudents(newStudent);

            // Assert
            Assert.IsFalse(_students.Contains(result));
        }
        [Test]
        //Test Fails
        public void AddStudent_ShouldNotAddStudentWithDuplicateEmail()
        {  
            var existingStudent = new Student
            {
                Name = "Existing Student",
                EmailId = "existing@gmail.com",
                PhoneNumber = 1234567,
            };
            _students.Add(existingStudent);

            var newStudent = new CreateDTO
            {
                Name = "Duplicate Email Student",
                EmailId = "existing@gmail.com", 
                PhoneNumber = 9876543,
            };

            _studentRepositoryMock.Setup(x => x.AddStudent(It.IsAny<Student>())).Callback<Student>(student =>
            {
                _students.Add(student);
            });
            var studentService = new StudentService(_studentRepositoryMock.Object, _mapper.Object);

            // Act
            var result = studentService.CreateStudents(newStudent);

            // Assert
            Assert.IsFalse(_students.Contains(result)); 
        }



        [Test]
        public void UpdateStudent_ShouldReturnTrueWhenStudentIsUpdated()
        {
            // Arrange
            int existingStudentId = 1;
            var existingStudent = _students.FirstOrDefault(s => s.StudentId == existingStudentId);

            _studentRepositoryMock.Setup(x => x.GetByIdDetails(existingStudentId)).Returns(existingStudent);
            _studentRepositoryMock.Setup(x => x.updateStudentRepo(It.IsAny<Student>(), existingStudentId));

            var updatedStudentDetails = new UpdateDTO
            {
                StudentId = existingStudentId,
                Name = "Updated Name",
                EmailId = "updatedemail@gmail.com",
                PhoneNumber = 9876543,
                // Add other properties as needed
            };

            _mapper.Setup(m => m.Map<UpdateDTO, Student>(updatedStudentDetails)).Returns(existingStudent);

            // Act
            var isUpdated = _studentService.UpdateStudent(updatedStudentDetails, existingStudentId);

            // Assert
            Assert.IsTrue(isUpdated);

        }

        [Test]
        public void DeleteStudent_ShouldReturnTrueWhenStudentIsDeleted()
        {
            // Arrange
            int existingStudentId = 1;
            var existingStudent = _students.FirstOrDefault(s => s.StudentId == existingStudentId);

            _studentRepositoryMock.Setup(x => x.GetByIdDetails(existingStudentId)).Returns(existingStudent);
            _studentRepositoryMock.Setup(x => x.DeleteById(existingStudent)).Returns("Student successfully deleted.");
            // Act
            bool isDeleted = _studentService.Deletestd(existingStudent);

            // Assert
            Assert.IsTrue(isDeleted);
        }
        [Test]
        public void DeleteStudent_ShouldCallDeleteById()
        {
            // Arrange
            int existingStudentId = 1;
            var existingStudent = _students.FirstOrDefault(s => s.StudentId == existingStudentId);

            _studentRepositoryMock.Setup(x => x.GetByIdDetails(existingStudentId)).Returns(existingStudent);

            // Act
            _studentService.Deletestd(existingStudent); 

            // Assert
            _studentRepositoryMock.Verify(x => x.DeleteById(existingStudent), Times.Once);
        }
        [Test]
        //Test fails
        public void DeleteStudent_ShouldCallDeleteByIdNeverUsed()
        {
            // Arrange
            int existingStudentId = 1;
            var existingStudent = _students.FirstOrDefault(s => s.StudentId == existingStudentId);

            _studentRepositoryMock.Setup(x => x.GetByIdDetails(existingStudentId)).Returns(existingStudent);

            // Act
            _studentService.Deletestd(existingStudent);

            // Assert
            _studentRepositoryMock.Verify(x => x.DeleteById(existingStudent), Times.Never);
        }

        [Test]
        public void DeleteStudent_ShouldCallDeletestdWithCorrectObject()
        {
            // Arrange
            int existingStudentId = 1;
            var existingStudent = _students.FirstOrDefault(s => s.StudentId == existingStudentId);

            // Act
            _studentService.Deletestd(existingStudent);

            // Assert
            _studentRepositoryMock.Verify(x => x.DeleteById(existingStudent), Times.Once);
        }

    }
}