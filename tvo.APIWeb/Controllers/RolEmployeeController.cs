using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class RolEmployeeController : Controller
    {
        private IRolEmployeeService _rolEmployeeService;

        public RolEmployeeController(IRolEmployeeService employeeService)
        {
            _rolEmployeeService = employeeService;
        }

        [HttpGet("ListRolEmployee")]
        public Task<IEnumerable<rolEmployee>> GetAllAsync()
        {
            return _rolEmployeeService.GetAllAsync();
        }

        [HttpPost("InsertRolEmployee")]
        public async Task<ActionResult> AddAsync([FromBody] rolEmployee newRolEmployee)
        {
            try
            {
                await _rolEmployeeService.AddAsync(newRolEmployee);
                return Ok("Rol de empleado registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar rol de empleado: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar rol de empleado" + ex.Message);
            }
        }

        [HttpPut("UpdateRolEmployee")]
        public async Task<ActionResult> UpdateAsync([FromBody] rolEmployee entity)
        {
            try
            {
                await _rolEmployeeService.UpdateAsync(entity);
                return Ok("Rol de empleado actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar rol de empleado: " + ex.Message);
                return StatusCode(500, "Error en el servidor al actualizar rol de empleado: " + ex.Message);
            }
        }

        [HttpDelete("DeleteRolEmployee/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var rolEmployee = await _rolEmployeeService.GetByIdAsync(id);
                if (rolEmployee == null)
                {
                    return NotFound("Rol de empleado no encontrado.");
                }
                await _rolEmployeeService.DeleteAsync(id);
                return Ok("Rol de empleado eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar rol de empleado: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar rol de empleado: " + ex.Message);
            }
        }

    }
}
