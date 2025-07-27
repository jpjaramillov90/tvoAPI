using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class WorkOrderController : Controller
    {
        private readonly IWorkOrderService _workOrderService;
        public WorkOrderController(IWorkOrderService workOrderService)
        {
            _workOrderService = workOrderService;
        }
        [HttpGet("ListWorkOrders")]
        public Task<IEnumerable<workOrder>> GetAllAsync()
        {
            return _workOrderService.GetAllAsync();
        }

        [HttpGet("GetWorkOrderById/{id}")]
        public async Task<ActionResult<workOrder>> GetByIdAsync(int id)
        {
            try
            {
                var workOrder = await _workOrderService.GetByIdAsync(id);
                if (workOrder == null)
                {
                    return NotFound("Orden de trabajo no encontrada.");
                }
                return Ok(workOrder);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener orden de trabajo: " + ex.Message);
                return StatusCode(500, "Error en el servidor al obtener orden de trabajo: " + ex.Message);
            }
        }

        [HttpGet("GetWorkOrdersByEmployeeId/{employeeId}")]
        public Task<List<EmployeeWorkOrdersDTO>> GetWorkOrdersByEmployeeId(int employeeId)
        {
            return _workOrderService.GetWorkOrdersByEmployeeId(employeeId);
        }

        [HttpGet("GetPendingWorkOrders")]
        public Task<List<PendingWorkOrderDTO>> GetPendingWorkOrders()
        {
            return _workOrderService.GetPendingWorkOrders();
        }

        [HttpPost("InsertWorkOrder")]
        public async Task<ActionResult> AddAsync([FromBody] workOrder newWorkOrder)
        {
            try
            {
                await _workOrderService.AddAsync(newWorkOrder);
                return Ok("Orden de trabajo registrada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar orden de trabajo: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar orden de trabajo: " + ex.Message);
            }
        }

        [HttpPut("UpdateWorkOrder")]
        public async Task<ActionResult> UpdateAsync([FromBody] workOrder updatedWorkOrder)
        {
            try
            {
                await _workOrderService.UpdateAsync(updatedWorkOrder);
                return Ok("Orden de trabajo actualizada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar orden de trabajo: " + ex.Message);
                return StatusCode(500, "Error en el servidor al actualizar orden de trabajo: " + ex.Message);
            }
        }

        [HttpPut("UpdateWorkOrderDTO")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateWorkOrderDTO updatedWorkOrderDTO)
        {
            try
            {
                // Mapear el DTO a la entidad workOrder
                var workOrder = new workOrder
                {
                    idWorkOrder = updatedWorkOrderDTO.idWorkOrder,
                    idEmployee = updatedWorkOrderDTO.idEmployee,
                    idOrderStatus = updatedWorkOrderDTO.idOrderStatus,
                    descriptionWO = updatedWorkOrderDTO.descriptionWO,
                    expires = updatedWorkOrderDTO.expires
                };

                await _workOrderService.UpdateAsync(workOrder);
                return Ok("Orden de trabajo actualizada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar orden de trabajo: " + ex.Message);
                return StatusCode(500, "Error en el servidor al actualizar orden de trabajo: " + ex.Message);
            }
        }

        [HttpDelete("DeleteWorkOrder/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var workOrder = await _workOrderService.GetByIdAsync(id);
                if (workOrder == null)
                {
                    return NotFound("Orden de trabajo no encontrada.");
                }
                await _workOrderService.DeleteAsync(id);
                return Ok("Orden de trabajo eliminada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar orden de trabajo: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar orden de trabajo: " + ex.Message);
            }
        }

        [HttpGet("SearchBudgetWithidwo/{idwo}")]
        public async Task<ActionResult<List<SearchBudgetDTO>>> SearchBudgetWithidwo(int idwo)
        {
            try
            {
                var budgets = await _workOrderService.SearchBudgetWithidwo(idwo);
                if (budgets == null || !budgets.Any())
                {
                    return NotFound("No se encontraron presupuestos con el NUI proporcionado.");
                }
                return Ok(budgets);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar presupuestos: " + ex.Message);
                return StatusCode(500, "Error en el servidor al buscar presupuestos: " + ex.Message);
            }
        }

        [HttpGet("GetTotalBudgetByidwo/{idwo}")]
        public async Task<ActionResult<TotalBudgetDTO>> GetTotalBudgetByidwo(int idwo)
        {
            try
            {
                var totalBudget = await _workOrderService.GetTotalBudgetByidwo(idwo);
                if (totalBudget == null)
                {
                    return NotFound("No se encontró presupuesto total para el NUI proporcionado.");
                }
                return Ok(totalBudget);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener presupuesto total: " + ex.Message);
                return StatusCode(500, "Error en el servidor al obtener presupuesto total: " + ex.Message);
            }
        }

    }
}