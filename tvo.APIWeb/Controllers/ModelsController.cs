using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class ModelsController : Controller
    {
        private IModelsService _modelsService;

        public ModelsController(IModelsService modelsService)
        {
            _modelsService = modelsService;
        }

        [HttpGet("ListModels")]
        public Task<IEnumerable<models>> GetAllAsync()
        {
            return _modelsService.GetAllAsync();
        }

        [HttpPost("InsertModels")]
        public async Task<ActionResult> AddAsync([FromBody] models newModels)
        {
            try
            {
                await _modelsService.AddAsync(newModels);
                return Ok("Modelo insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar modelo: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al insertar cooperativa: " + ex.Message);
            }
        }
    }
}
