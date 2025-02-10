using AutoMapper;
using KindyCity.Application.Commands.Auth.Create;
using KindyCity.Application.Commands.EmployeeCommand.Create;
using KindyCity.Application.Models.Response;
using KindyCity.Domain.Entites;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // Map từ User (Entity) sang UserDto (DTO)
        CreateMap <Employee, EmployeeResponseDto>();
        CreateMap <CreateEmployeeCommand, Employee>();
        CreateMap <CreateEmployeeCommand, EmployeeInfo>();
        CreateMap <CreateEmployeeCommand, EmployeeEducation>();

        // Map từ CreateUserRequest (DTO) sang User (Entity)
        CreateMap<CreateUserCommand, Employee>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
            .ForMember(dest => dest.CreateOn, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.LastSignInTime, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}