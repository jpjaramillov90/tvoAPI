using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class OrderStatusController : Controller
    {
        private IOrderStatusService _orderStatus;

        public OrderStatusController(IOrderStatusService orderStatus)
        {
            _orderStatus = orderStatus;
        }

        [HttpGet("ListOrderStatus")]
        public Task<IEnumerable<orderStatus>> GetAllAsync()
        {
            return _orderStatus.GetAllAsync();
        }

        [HttpPost("InsertOrderStatus")]
        public async Task<ActionResult> AddAsync([FromBody] orderStatus newOrderStatus)
        {
            try
            {
                await _orderStatus.AddAsync(newOrderStatus);
                return Ok("Estado de orden registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar estado de orden: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar orden" + ex.Message);
            }
        }
        [HttpDelete("DeleteOrderStatus/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var orderStatus = await _orderStatus.GetByIdAsync(id);
                if (orderStatus == null)
                {
                    return NotFound("Estado de orden no encontrado.");
                }
                await _orderStatus.DeleteAsync(id);
                return Ok("Estado de orden eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar estado de orden: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar estado de orden: " + ex.Message);
            }
        }
    }
}
