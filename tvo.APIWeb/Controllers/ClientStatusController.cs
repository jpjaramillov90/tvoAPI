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
    }
}
