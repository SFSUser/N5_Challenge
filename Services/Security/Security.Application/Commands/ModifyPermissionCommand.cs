using MediatR;
using Security.Application.Response;
using System;

namespace Security.Application.Commands
{
    /// <summary>
    /// ModifyPermissionCommand class
    /// </summary>
    public class ModifyPermissionCommand : IRequest<PermissionResponse>
    {
        public Int64 Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}
