// Mappings/AutoMapperProfile.cs
using AutoMapper;
using HouseRules.Models;
using HouseRules.Models.DTOs;

namespace HouseRules.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Chore, ChoreDto>();

        CreateMap<ChoreAssignment, ChoreAssignmentDto>();

        CreateMap<ChoreCompletion, ChoreCompletionDto>();

        CreateMap<UserProfile, UserProfileDTO>()
            .ForMember(dest => dest.UserName,
                       opt => opt.MapFrom(src => src.IdentityUser.UserName))
            .ForMember(dest => dest.Email,
                       opt => opt.MapFrom(src => src.IdentityUser.Email))
            .ForMember(dest => dest.Roles,
                       opt => opt.Ignore());
    }
}