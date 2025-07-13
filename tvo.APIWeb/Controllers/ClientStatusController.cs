using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class ClientStatusController : Controller
    {
        private IClientStatusService _clientStatusService;

        public ClientStatusController(IClientStatusService clientStatusService)
        {
            _clientStatusService = clientStatusService;
        }

        [HttpGet("ListClientStatus")]
        public Task<IEnumerable<clientStatus>> GetAllAsync() 
        {
            return _clientStatusService.GetAllAsync();
        }

        [HttpPost("InsertClientStatus")]
        public async Task<ActionResult> AddAsync([FromBody] clientStatus newCS)
        {
            try
            {
                await _clientStatusService.AddAsync(newCS);
                return Ok("Estado de cliente insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar estado de cliente: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al insertar estado de cliente: " + ex.Message);
            }
        }

        [HttpDelete("DeleteClientStatus/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var clientStatus = await _clientStatusService.GetByIdAsync(id);
                if (clientStatus == null)
                {
                    return NotFound("Estado de cliente no encontrado.");
                }
                await _clientStatusService.DeleteAsync(id);
                return Ok("Estado de cliente eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar estado de cliente: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al eliminar estado de cliente: " + ex.Message);
            }
        }

    }
}
