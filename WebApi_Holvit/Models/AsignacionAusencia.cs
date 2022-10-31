namespace WebApi_Holvit.Models
{
    public class AsignacionAusencia
    {
        public int Id { get; set; }
        public int NumeroDeDias { get; set; }
        public DateTime DiasCreados { get; set; }
        public int Periodo { get; set; }
        public Empleados Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public Ausencias Ausencia { get; set; }
        public int AusenciaId { get; set; }
    }
    public class CrearAsignacion
    {
        public int NumeroActualizado { get; set; }
        public List<Ausencias> TipoDeLicencias { get; set; }
    }

    public class EditarAsignacion
    {
        public int Id { get; set; }
        public Empleados Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public int NumeroDeDias { get; set; }
        public Ausencias TipoDeLicencia { get; set; }
    }

    public class VerAsignacionAusencia
    {
        public Empleados Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public List<AsignacionAusencia> AsignacionesDeAusencia { get; set; }
    }
}
