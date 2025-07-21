using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class BrandsController : Controller
    {
        private IBrandsService _brandsService;

        public BrandsController(IBrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        [HttpGet("ListBrands")]
        public Task<IEnumerable<brands>> GetAllAsync()
        {
            return _brandsService.GetAllAsync();
        }

        [HttpPost("InsertBrand")]
        public async Task<ActionResult> AddAsync([FromBody] brands newBrand)
        {
            try
            {
                await _brandsService.AddAsync(newBrand);
                return Ok("Marca insertada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar marca: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al insertar marca: " + ex.Message);
            }
        }

        [HttpPut("UpdateBrand")]
        public async Task<ActionResult> UpdateAsync([FromBody] brands entity)
        {
            try
            {
                await _brandsService.UpdateAsync(entity);
                return Ok("Marca actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar marca: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al actualizar marca: " + ex.Message);
            }
        }

        [HttpDelete("DeleteBrand/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var brand = await _brandsService.GetByIdAsync(id);
                if (brand == null)
                {
                    return NotFound("Marca no encontrada.");
                }
                await _brandsService.DeleteAsync(id);
                return Ok("Marca eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar marca: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al eliminar marca: " + ex.Message);
            }
        }

    }
}
