using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class SpecialtiesController : Controller
    {
        private ISpecialtiesService _specialtiesService;
        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }

        [HttpGet("ListSpecialitiesByName/{specialitie}")]
        public Task<List<specialties>> ListSpecialties(string specialitie)
        { 
            return _specialtiesService.ListSpecialties(specialitie);
        }

        [HttpGet("ListSpecialities")]
        public Task<IEnumerable<specialties>> GetAllAsync()
        {
            return _specialtiesService.GetAllAsync();
        }

        [HttpPost("InsertSpecialitie")]
        public async Task<ActionResult> AddAsync([FromBody] specialties newSpecialitie)
        {
            try
            {
                await _specialtiesService.AddAsync(newSpecialitie);
                return Ok("Especialidad registrada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar espcialidad: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar espcialidad" + ex.Message);
            }
        }

        [HttpDelete("DeleteSpecialitie/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var specialitie = await _specialtiesService.GetByIdAsync(id);
                if (specialitie == null)
                {
                    return NotFound("Especialidad no encontrada.");
                }
                await _specialtiesService.DeleteAsync(id);
                return Ok("Especialidad eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar especialidad: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar especialidad: " + ex.Message);
            }
        }
    }
}
