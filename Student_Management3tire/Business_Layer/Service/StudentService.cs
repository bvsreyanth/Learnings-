using AutoMapper;
using Business_Layer.DTO;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repositorys;

namespace Business_Layer.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentrepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentrepository, IMapper mapper)
        {
            _studentrepository = studentrepository;
            _mapper = mapper;
        }
        public List<Student> GetAll()
        {
            return _studentrepository.getalldetails().ToList();
        }

        public Student GetById(int id)
        {
            return _studentrepository.GetByIdDetails(id);
        }
        public Student CreateStudents(CreateDTO createdto)
        {
            var result = _mapper.Map<Student>(createdto);
            _studentrepository.AddStudent(result);
            return result;
        }
  
        public bool UpdateStudent(UpdateDTO student,int id)
        {
            if(student.StudentId==id)
            {
               var result =  _mapper.Map<Student>(student);
                _studentrepository.updateStudentRepo(result,id);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        public bool UpdateStudt(UpdateDTO students, int id)
        {
            var patchedstudents = _mapper.Map<Student>(students);
            //_studentrepository.patchStudent(patchedstudents);
            return true;
        }
        public void UpdateStudentPartial(UpdateDTO studentDTO, int id)
        {
            var patchedstudent = _mapper.Map<Student>(studentDTO);
            _studentrepository.PatchStudent(patchedstudent);
            
        }
        public bool Deletestd(Student result)
        {
            _studentrepository.DeleteById(result);
            return true;
        }

        
    }
}
