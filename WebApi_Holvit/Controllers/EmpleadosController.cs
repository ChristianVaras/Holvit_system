using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApi_Holvit.Models;

namespace WebApi_Holvit.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly string cadenaSQL;

        public EmpleadosController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("TivitConexion");
        }

        // GET: api/Empleados
        [HttpGet]
        public IActionResult Lista()
        {
            List<Empleados> lista = new();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {

                    conexion.Open();
                    var cmd = new SqlCommand("uspDatosEmpleados", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using var rd = cmd.ExecuteReader();
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Empleados()
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Nombre = rd["Nombre"].ToString(),
                                Cargo = rd["Cargo"].ToString(),
                                SuperiorId = Convert.ToInt32(rd["SuperiorId"]),
                                Sede = Convert.ToInt32(rd["Sede"]),
                                Rol = Convert.ToInt32(rd["Rol"]),
                                Email = rd["Email"].ToString(),
                                Estatus = Convert.ToBoolean(rd["Estatus"]),
                                FechaIngreso = Convert.ToDateTime(rd["FechaIngreso"]),
                                FechaNacimiento = Convert.ToDateTime(rd["FechaNacimiento"]),
                                SaldoVacaciones = Convert.ToDecimal(rd["SaldoVacaciones"]),
                            });
                        }
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }

        }

        // GET: api/Empleados/5
        [HttpGet]
        [Route("id")]
        public IActionResult Obtener(int idEmpleado)
        {
            List<Empleados> lista = new();
            Empleados empleado = new Empleados();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {

                    conexion.Open();
                    var cmd = new SqlCommand("uspDatosEmpleados", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using var rd = cmd.ExecuteReader();
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Empleados()
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Nombre = rd["Nombre"].ToString(),
                                Cargo = rd["Cargo"].ToString(),
                                SuperiorId = Convert.ToInt32(rd["SuperiorId"]),
                                Sede = Convert.ToInt32(rd["Sede"]),
                                Rol = Convert.ToInt32(rd["Rol"]),
                                Email = rd["Email"].ToString(),
                                Estatus = Convert.ToBoolean(rd["Estatus"]),
                                FechaIngreso = Convert.ToDateTime(rd["FechaIngreso"]),
                                FechaNacimiento = Convert.ToDateTime(rd["FechaNacimiento"]),
                                SaldoVacaciones = Convert.ToDecimal(rd["SaldoVacaciones"]),
                            });
                        }
                    }
                }
                empleado = lista.Where(item => item.Id == idEmpleado).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = empleado });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }
        }
    }
}
