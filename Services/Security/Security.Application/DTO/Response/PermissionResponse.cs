using System;
using Security.Core.Entities;

namespace Security.Application.DTO.Response
{
    public class PermissionResponse
    {
        public long Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
        public PermissionsType PermissionsType { get; set; }
    }
}
