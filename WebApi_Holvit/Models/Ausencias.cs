using System.ComponentModel.DataAnnotations;

namespace WebApi_Holvit.Models
{
    public class Ausencias
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Número de Días")]
        [Range(1, 30, ErrorMessage = "Por favor ingresa un número válido")]
        public int NumeroDeDias { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime? FechaCreacion { get; set; }
    }
}
