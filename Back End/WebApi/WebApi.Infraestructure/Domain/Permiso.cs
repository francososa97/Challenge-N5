using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Infraestructure.Domain;

[Table("Permisos")]
public partial class Permiso
{
    [Column("Id")]
    public int Id { get; set; }

    [Column("NombreEmpleado")]
    public string NombreEmpleado { get; set; }

    [Column("ApellidoEmpleado")]
    public string ApellidoEmpleado { get; set; }

    [Column("TipoPermiso")]
    public int TipoPermiso { get; set; }

    [Column("FechaPermiso")]
    public DateTime FechaPermiso { get; set; }
}