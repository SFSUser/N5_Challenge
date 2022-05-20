using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Security.Core.Entities.Base;

namespace Security.Core.Entities
{
    [Table("TipoPermisos")]
    public class PermissionsType: BaseEntity
    {
        public string Descripcion { get; set; }
    }
}