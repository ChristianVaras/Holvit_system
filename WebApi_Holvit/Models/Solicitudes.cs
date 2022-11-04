using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApi_Holvit.Models
{
    public class Solicitudes
    {
        public int Id { get; set; }
        public Empleados Empleado { get; set; }
        public int EmpleadoId { get; set; }

        public string AusenciaId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaInicioProg { get; set; }
        public DateTime FechaFinProg { get; set; }
        public DateTime FechaInicioReal { get; set; }
        public DateTime FechaFinReal { get; set; }
        public DateTime FechaAprobacion { get; set; }
                
        [Display(Name = "Descripción")]
        [MaxLength(300)]
        public string Descripcion { get; set; }

        public Int16 EstatusSolicitud { get; set; }
        public DateTime UltimaModif { get; set; }
        
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
        public string FechaInicioProg { get; set; }
        public string FechaFinProg { get; set; }
        public IEnumerable<SelectListItem> Ausencia { get; set; }
        public int AusenciaId { get; set; }
        [MaxLength(300)]
        public string Descripcion { get; set; }

    }

    public class EmpleadoSolicitud
    {
        public List<AsignacionAusencia> AsignacionesAusencia { get; set; }
        public List<Solicitudes> SolicitudesAusencia { get; set; }
    }
}
