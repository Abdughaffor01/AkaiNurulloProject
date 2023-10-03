using AutoMapper;
using Domain;
using Domain.DTOs.StudentDTOs;

namespace Infrastructure.AutoMapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Student, AddStudentDto>();
        CreateMap<AddStudentDto,Student>();
        CreateMap<Student,GetStudentDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender == Gender.Male ? "Male" : "Female"));
        CreateMap<BaseStudentDto, Student>().ReverseMap();
    }
}
