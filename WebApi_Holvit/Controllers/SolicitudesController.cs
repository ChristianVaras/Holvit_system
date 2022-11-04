using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebApi_Holvit.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace WebApi_Holvit.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly string cadenaSQL;

        public SolicitudesController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("TivitConexion");
        }

        // GET: api/<Solicitudes>
        [HttpGet]
        public IActionResult Lista()
        {
            List<Solicitudes> lista = new();

            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {

                    conexion.Open();
                    var cmd = new SqlCommand("uspSolicitudes", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using var rd = cmd.ExecuteReader();
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Solicitudes()
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                EmpleadoId = Convert.ToInt32(rd["EmpleadoId"]),
                                AusenciaId = rd["AusenciaId"].ToString(),
                                FechaSolicitud = Convert.ToDateTime(rd["FechaSolicitud"]),
                                FechaInicioProg = Convert.ToDateTime(rd["FechaInicioProg"]),
                                FechaFinProg = Convert.ToDateTime(rd["FechaFinProg"]),
                                FechaInicioReal = Convert.ToDateTime(rd["FechaInicioReal"]),
                                FechaFinReal = Convert.ToDateTime(rd["FechaFinReal"]),
                                FechaAprobacion = Convert.ToDateTime(rd["FechaAprobacion"]),
                                Descripcion = rd["Descripcion"].ToString(),
                                EstatusSolicitud = Convert.ToInt16(rd["EstatusSolicitud"]),
                                UltimaModif = Convert.ToDateTime(rd["UltimaModif"])
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

        // GET api/<Solicitudes>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Solicitudes>
        [HttpPost]
        public IActionResult Post([FromBody] Solicitudes objeto)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {

                    conexion.Open();
                    var cmd = new SqlCommand("uspGuardarSolicitud", conexion);
                    cmd.Parameters.AddWithValue("AusenciaId",objeto.AusenciaId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.ExecuteNonQuery();
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message});
            }

        }

        // PUT api/<Solicitudes>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Solicitudes>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
