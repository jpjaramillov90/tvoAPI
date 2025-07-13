using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class CooperativeController : Controller
    {
        private ICooperativeService _cooperativeService;

        public CooperativeController(ICooperativeService cooperativeService)
        {
            _cooperativeService = cooperativeService;
        }

        [HttpGet("ListCooperatives")]
        public Task<IEnumerable<cooperative>> GetAllAsync()
        {
            return _cooperativeService.GetAllAsync();
        }

        [HttpPost("InsertCoorperative")]
        public async Task<ActionResult> AddAsync([FromBody] cooperative newCoop)
        {
            try
            {
                await _cooperativeService.AddAsync(newCoop);
                return Ok("Cooperativa insertada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar cooperativa: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al insertar cooperativa: " + ex.Message);
            }
        }

        [HttpDelete("DeleteCoorperative/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var cooperative = await _cooperativeService.GetByIdAsync(id);
                if (cooperative == null)
                {
                    return NotFound("Cooperativa no encontrada.");
                }
                await _cooperativeService.DeleteAsync(id);
                return Ok("Cooperativa eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar cooperativa: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al eliminar cooperativa: " + ex.Message);
            }
        }
    }
}
