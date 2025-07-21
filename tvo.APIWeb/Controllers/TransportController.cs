using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class TransportController : Controller
    {
        private readonly ITransportService _transportService;
        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }
        [HttpGet("ListTransport")]
        public Task<IEnumerable<transport>> GetAllAsync()
        {
            return _transportService.GetAllAsync();
        }
        [HttpPost("InsertTransport")]
        public async Task<ActionResult> AddAsync([FromBody] transport newTransport)
        {
            try
            {
                await _transportService.AddAsync(newTransport);
                return Ok("Transporte registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar transporte: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar transporte: " + ex.Message);
            }
        }

        [HttpPut("UpdateTransport")]
        public async Task<ActionResult> UpdateAsync([FromBody] transport entity)
        {
            try
            {
                await _transportService.UpdateAsync(entity);
                return Ok("Transporte actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar transporte: " + ex.Message);
                return StatusCode(500, "Error en el servidor al actualizar transporte: " + ex.Message);
            }
        }

        [HttpDelete("DeleteTransport/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var transport = await _transportService.GetByIdAsync(id);
                if (transport == null)
                {
                    return NotFound("Transporte no encontrado.");
                }
                await _transportService.DeleteAsync(id);
                return Ok("Transporte eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar transporte: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar transporte: " + ex.Message);
            }
        }
    }
}
