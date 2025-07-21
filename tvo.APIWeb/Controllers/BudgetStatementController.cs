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
                return Ok("Estado del presupuesto insertado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar estado del presupuesto: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al insertar estado del presupuesto: " + ex.Message);
            }
        }

        [HttpPut("UpdateBudgetStatement")]
        public async Task<ActionResult> UpdateAsync([FromBody] budgetStatement entity)
        {
            try
            {
                await _budgetStatementService.UpdateAsync(entity);
                return Ok("Estado del presupuesto actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar estado del presupuesto: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al actualizar estado del presupuesto: " + ex.Message);
            }
        }

        [HttpDelete("DeleteBudgetStatement/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var budgetStatement = await _budgetStatementService.GetByIdAsync(id);
                if (budgetStatement == null)
                {
                    return NotFound("Estado del presupuesto no encontrado.");
                }
                await _budgetStatementService.DeleteAsync(id);
                return Ok("Estado del presupuesto eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar estado del presupuesto: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al eliminar estado del presupuesto: " + ex.Message);
            }

        }
    }
}
