using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo_06_CRUD_Razor_server.Models;

[Table("Respuestas")]
[IgnoreAntiforgeryToken]
public class Respuesta
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Column("Email")]
    public string Email { get; set; }

    [Column("Camina")]
    public bool Camina { get; set; }

    [Column("Usa_Transporte_Publico")]
    public bool UsaTransportePublico { get; set; }

    [Column("Usa_Transporte_Privado")]
    public bool UsaTransportePrivado { get; set; }

    [Column("Usa_Transporte_Destino")]
    public decimal DistanciaASuDestino { get; set; }
}
