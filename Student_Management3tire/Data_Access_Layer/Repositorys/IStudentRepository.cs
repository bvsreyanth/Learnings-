using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositorys
{
    public interface IStudentRepository
    {
        public List<Student> getalldetails();
        public Student GetByIdDetails(int id);
        public string AddStudent(Student student);
        public string DeleteById(Student student);
        void updateStudentRepo(Student result,int id);
        public void PatchStudent(Student patchedstudent);
    }
}
