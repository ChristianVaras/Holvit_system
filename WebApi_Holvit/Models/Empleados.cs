namespace WebApi_Holvit.Models
{
    public class Empleados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public int SuperiorId { get; set; }
        public int Sede { get; set; }
        public int Rol { get; set; }
        public string Email { get; set; }
        public bool Estatus { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime DiasDeVacaciones { get; set; }
    }

}
