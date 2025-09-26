using Data_Access_Layer.Data;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositorys
{
    public class StudentRepository : IStudentRepository
    {
       private readonly StudentDbContext _studentDbContext;
        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
       
        public List<Student> getalldetails()
        {
            return _studentDbContext.students.ToList();
        }

        public Student GetByIdDetails(int id)
        {
          return _studentDbContext.students.FirstOrDefault(s => s.StudentId == id);
        }
        public string AddStudent(Student student)
        {
            _studentDbContext.Add(student);
            _studentDbContext.SaveChanges();
            return "Student Created";
        }
        public void updateStudentRepo(Student Updatestudent,int id)
        {
           var result = _studentDbContext.students.FirstOrDefault(u=>u.StudentId == id);
            if(result != null)
            {
                //var mapper = _mapper.Map<Updatestudent, Student>(Updatestudent, result);
                result.StudentId = Updatestudent.StudentId;
                result.Name = Updatestudent.Name;
                result.PhoneNumber = Updatestudent.PhoneNumber;
                result.EmailId = Updatestudent.EmailId;
            }
            _studentDbContext.students.Update(result);
            _studentDbContext.SaveChanges();
        }
        public void PatchStudent(Student patchedstudents)
        {
            _studentDbContext.Update(patchedstudents);
            _studentDbContext.SaveChanges();
        }

        public string DeleteById(Student student)
        {
            _studentDbContext.Remove(student);
            _studentDbContext.SaveChanges();
            return "Student Deleted";
        }
    }
}
