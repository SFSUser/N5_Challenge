using MediatR;
using Security.Application.DTO.Response;
using System;

namespace Security.Application.CQRS.Commands
{
    /// <summary>
    /// ModifyPermissionCommand class
    /// </summary>
    public class ModifyPermissionCommand : IRequest<PermissionResponse>
    {
        public long Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}
