using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApi_Holvit.Models
{
    public class Solicitudes
    {
        public int Id { get; set; }
        public Empleados Empleado { get; set; }
        [Display(Name = "Nombre de Empleado")]
        public int EmpleadoId { get; set; }

        public string AusenciaId { get; set; }
        [Display(Name = "Fecha de Solicitud")]
        [DataType(DataType.Date)]
        public DateTime FechaSolicitud { get; set; }
        [Display(Name = "Fecha de Inicio Programada")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicioProg { get; set; }
        [Display(Name = "Fecha Final Programada")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFinProg { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicioReal { get; set; }
        [Display(Name = "Fecha Final")]
        public DateTime FechaFinReal { get; set; }
        [Display(Name = "Estado de solicitud")]
        public bool? Aprobada { get; set; }
        public bool Rechazada { get; set; }
        public Empleados Supervisor { get; set; }
        [Display(Name = "Nombre de Supervisor")]
        public string SupervisorId { get; set; }

        [Display(Name = "Última Modificación")]
        public DateTime UltimaModif { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(300)]
        public string Descripcion { get; set; }
        [Display(Name = "Fecha de Aprobación")]
        [DataType(DataType.Date)]
        public DateTime FechaAprobacion { get; set; }
    }
    public class AdminSolicitudes
    {
        [Display(Name = "Número de Solicitudes")]
        public int TotalSolicitudes { get; set; }
        [Display(Name = "Solicitudes Aprobadas")]
        public int SolicitudesAprobadas { get; set; }
        [Display(Name = "Solicitudes Pendientes")]
        public int SolicitudesPendientes { get; set; }
        [Display(Name = "Solicitudes Rechazadas")]
        public int SolicitudesRechazadas { get; set; }
        public List<Solicitudes> SolicitudesAusencia { get; set; }
    }

    public class CrearSolicitud
    {
        [Display(Name = "Fecha de Inicio")]
        [Required]
        public string FechaInicioProg { get; set; }
        [Display(Name = "Fecha Final")]
        [Required]
        public string FechaFinProg { get; set; }
        public IEnumerable<SelectListItem> Ausencia { get; set; }
        [Display(Name = "Tipo de Ausencia")]
        public int AusenciaId { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(300)]
        public string Descripcion { get; set; }

    }

    public class EmpleadoSolicitud
    {
        public List<AsignacionAusencia> AsignacionesAusencia { get; set; }
        public List<Solicitudes> SolicitudesAusencia { get; set; }
    }
}
