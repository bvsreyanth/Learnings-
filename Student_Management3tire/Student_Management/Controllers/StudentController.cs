using AutoMapper;
using Business_Layer.DTO;
using Business_Layer.Service;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Student_Management.Controllers
{
    [Route("Api/[Controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        [HttpGet]

        public IActionResult GetStudents()
        {
            try
            {
                List<Student> students = _studentService.GetAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id:int}", Name = "GetVilla")]
        public IActionResult GetByIdDetails(int id)
        {

            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                var getid = _studentService.GetById(id);
                return Ok(getid);
                //var dataDto = new EmployeeForShortDto()
                //{
                //    StudentId = getid.StudentId,
                //    PhoneNumber = getid.PhoneNumber,
                //    Name = getid.Name,
                //    EmailId = getid.EmailId
                //};
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateStudent([FromBody] CreateDTO student)
        {
            try
            {
                var result = _studentService.CreateStudents(student);
                return Ok("Sudent created successfully");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Updatestudent")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || updateDTO.StudentId != id)
                {
                    return BadRequest("Invalid input");
                }

                var result = _studentService.GetById(id);
                if (result == null)
                {
                    return NoContent();
                }
                _studentService.UpdateStudent(updateDTO, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("{id}")]
        public IActionResult PatchStudent(int id, [FromBody] JsonPatchDocument<UpdateDTO> patchDTO)
        {
            try
            {
                if (id == 0 || patchDTO == null)
                {
                    return BadRequest("Invalid input: ID or patch data is missing.");
                }

                var studentToUpdate = _studentService.GetById(id);


                if (studentToUpdate == null)
                {
                    return NotFound("Student not found.");
                }

                var studentDTO = _mapper.Map<UpdateDTO>(studentToUpdate);

                patchDTO.ApplyTo(studentDTO, ModelState);
                Console.WriteLine(studentDTO);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _studentService.UpdateStudentPartial(studentDTO, id);

                //if (updatedStudent == null)
                //{
                //    return BadRequest("Failed to update student data.");
                //}

                return Ok(); // Return updated student data
            }
            catch (Exception ex)
            {

                // Log the exception for debugging purposes
                // logger.LogError(ex, "An error occurred while processing the PATCH request.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }


        [HttpDelete("id")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var result = _studentService.GetById(id);
                _studentService.Deletestd(result);
                return Ok("Student Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
