using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Dto
{
    public class PermisionsDTO
    {
        public string NombreEmpleado { get; set; } = null!;

        public string ApellidoEmpleado { get; set; } = null!;

        public int TipoPermiso { get; set; }

        public DateTime FechaPermiso { get; set; }
    }
}
