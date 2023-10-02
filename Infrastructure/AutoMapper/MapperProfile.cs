using AutoMapper;
using Domain;

namespace Infrastructure;
public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Student, AddStudentDto>().ReverseMap();
        CreateMap<GetStudentDto, Student>().ReverseMap()
            .ForMember(sDto => sDto.FulName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
            .ForMember(sDto => sDto.EmailAddress, opt => opt.MapFrom(s =>s.Email));
        CreateMap<BaseStudentDto,Student>().ReverseMap();

            
    }
}
