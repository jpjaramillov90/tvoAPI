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

        [HttpPut("UpdateServicePrice")]
        public async Task<ActionResult> UpdateAsync([FromBody] servicePrice entity)
        {
            try
            {
                await _servicePriceService.UpdateAsync(entity);
                return Ok("Precio de servicio actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar precio de servicio: " + ex.Message);
                return StatusCode(500, "Error en el servidor al actualizar precio de servicio: " + ex.Message);
            }
        }

        [HttpDelete("DeleteServicePrice/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var servicePrice = await _servicePriceService.GetByIdAsync(id);
                if (servicePrice == null)
                {
                    return NotFound("Precio de servicio no encontrado.");
                }
                await _servicePriceService.DeleteAsync(id);
                return Ok("Precio de servicio eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar precio de servicio: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar precio de servicio: " + ex.Message);
            }

        }
    }
}
