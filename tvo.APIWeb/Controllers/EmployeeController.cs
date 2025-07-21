using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("ListEmployee")]
        public Task<IEnumerable<employee>> GetAllAsync()
        {
            return _employeeService.GetAllAsync();
        }

        [HttpPost("InsertEmployee")]
        public async Task<ActionResult> AddAsync([FromBody] employee newEmployee)
        {
            try
            {
                await _employeeService.AddAsync(newEmployee);
                return Ok("Empleado registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar empleado: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar empleado" + ex.Message);
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult> UpdateAsync([FromBody] employee entity)
        {
            try
            {
                await _employeeService.UpdateAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar empleado: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al actualizar empleado: " + ex.Message);
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee == null)
                {
                    return NotFound("Empleado no encontrado.");
                }
                await _employeeService.DeleteAsync(id);
                return Ok("Empleado eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar empleado: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar empleado: " + ex.Message);
            }
        }

    }
}
