using AutoMapper;
using Security.Application.Commands;
using Security.Application.Response;
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
