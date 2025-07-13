using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class ServicesController : Controller
    {
        private IServicesService _servicesService;
        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet("GetServicesByMinPrice/{minPrice}")]
        public Task<List<ServicePriceDTO>> GetServicesByMinPrice(decimal minPrice)
        {
            return _servicesService.GetServicesByMinPrice(minPrice);
        }

        [HttpGet("ListServices")]
        public Task<IEnumerable<services>> GerAllAsync()
        {
            return _servicesService.GetAllAsync();
        }

        [HttpPost("InsertService")]
        public async Task<ActionResult> AddAsync([FromBody] services newService)
        {
            try
            {
                await _servicesService.AddAsync(newService);
                return Ok("Servicio registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar servicio: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar servicio" + ex.Message);
            }
        }
        [HttpDelete("DeleteService/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var service = await _servicesService.GetByIdAsync(id);
                if (service == null)
                {
                    return NotFound("Servicio no encontrado.");
                }
                await _servicesService.DeleteAsync(id);
                return Ok("Servicio eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar servicio: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar servicio: " + ex.Message);
            }

        }
    }
}
