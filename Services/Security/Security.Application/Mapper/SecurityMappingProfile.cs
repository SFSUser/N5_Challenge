using AutoMapper;
using Security.Application.Commands;
using Security.Application.Response;
using Security.Core.Entities;

namespace Security.Application.Mapper
{
    /// <summary>
    /// Mapper class for mapping commands to entities
    /// </summary>
    public class SecurityMappingProfile : Profile
    {
        public SecurityMappingProfile()
        {
            CreateMap<Permissions, PermissionResponse>().ReverseMap();
            CreateMap<Permissions, ModifyPermissionCommand>().ReverseMap();
        }
    }
}
