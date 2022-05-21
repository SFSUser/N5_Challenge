using AutoMapper;
using Security.Application.CQRS.Commands;
using Security.Application.DTO.Response;
using Security.Core.Entities;

namespace Security.Application.Mapper
{
    public class SecurityMappingProfile : Profile
    {
        public SecurityMappingProfile()
        {
            CreateMap<Permissions, PermissionResponse>().ReverseMap();
            CreateMap<Permissions, ModifyPermissionCommand>().ReverseMap();
        }
    }
}
