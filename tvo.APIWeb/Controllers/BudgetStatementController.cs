using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class BudgetStatementController : Controller
    {
        private IBudgetStatementService _budgetStatementService;

        public BudgetStatementController(IBudgetStatementService budgetStatementService)
        {
            _budgetStatementService = budgetStatementService;
        }

        [HttpGet("ListBudgetStatements")]
        public Task<IEnumerable<budgetStatement>> GetAllAsync() 
        {
            return _budgetStatementService.GetAllAsync();
        }

        [HttpPost("InsertBudgetStatement")]
        public async Task<ActionResult> AddAsync([FromBody] budgetStatement newbs)
        {
            try 
            { 
            await _budgetStatementService.AddAsync(newbs);
            return Ok("Estado de marca insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar estado de marca: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al insertar estado de marca: " + ex.Message);
            }
        }

    }
}
