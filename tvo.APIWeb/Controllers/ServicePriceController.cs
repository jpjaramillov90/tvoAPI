using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class ServicePriceController : Controller
    {
        private IServicePriceService _servicePriceService;
        public ServicePriceController(IServicePriceService servicePriceService)
        {
            _servicePriceService = servicePriceService;
        }

        [HttpGet("ListServicePrice")]
        public Task<IEnumerable<servicePrice>> GetAllAsync()
        {
            return _servicePriceService.GetAllAsync();
        }

        [HttpPost("InsertServicePrice")]
        public async Task<ActionResult> AddAsync([FromBody] servicePrice newServicePrice)
        {
            try
            {
                await _servicePriceService.AddAsync(newServicePrice);
                return Ok("Precio de servicio registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar precio de servicio: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar precio de servicio" + ex.Message);
            }
        }
    }
}
