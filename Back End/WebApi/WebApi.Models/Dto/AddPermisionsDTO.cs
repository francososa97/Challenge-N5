using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models.Enum;

namespace WebApi.Models.Dto
{
    public class AddPermisionsDTO
    {
        public string NombreEmpleado { get; set; } = null!;

        public string ApellidoEmpleado { get; set; } = null!;

        public TypePermision TipoPermiso { get; set; }

        public string FechaPermiso { get; set; }
    }
}
