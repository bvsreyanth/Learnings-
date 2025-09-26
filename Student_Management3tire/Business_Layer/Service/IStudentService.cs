using Business_Layer.DTO;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Service
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        Student CreateStudents(CreateDTO create);
        //Patch

        bool Deletestd(Student student);
        public bool UpdateStudent(UpdateDTO updateDTO, int id);
        public void UpdateStudentPartial(UpdateDTO studentDTO, int id);
    }
}
