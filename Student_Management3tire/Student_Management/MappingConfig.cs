using AutoMapper;
using Business_Layer.DTO;
using Data_Access_Layer.Models;

namespace Student_Management
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Student,CreateDTO>();
            CreateMap<CreateDTO, Student>();
            CreateMap<Student,UpdateDTO>().ReverseMap(); 
        }
    }
}
