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
                Console.WriteLine("Error al insertar rol: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar rol" + ex.Message);
            }
        }
    }
}
