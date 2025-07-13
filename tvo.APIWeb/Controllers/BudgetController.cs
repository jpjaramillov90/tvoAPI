using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class BudgetController: Controller
    {
        private IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet("ListBudget")]
        public Task<IEnumerable<budget>> GetAllAsync()
        {
            return _budgetService.GetAllAsync();
        }

        [HttpPost("InsertBudget")]
        public async Task<ActionResult> AddAsync([FromBody] budget newBudget)
        {
            try
            {
                await _budgetService.AddAsync(newBudget);
                return Ok("Marca insertada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar marca: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al insertar marca: " + ex.Message);
            }
        }

    }
}
