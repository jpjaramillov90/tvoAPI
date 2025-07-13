using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class OrderDetailsController : Controller
    {
        private IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet("ListOrderDetails")]
        public Task<IEnumerable<orderDetails>> GetAllAsync()
        {
            return _orderDetailsService.GetAllAsync();
        }

        [HttpPost("InsertOrderDetail")]
        public async Task<ActionResult> AddAsync([FromBody] orderDetails newOrderDetail)
        {
            try
            {
                await _orderDetailsService.AddAsync(newOrderDetail);
                return Ok("Empleado registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar empleado: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar empleado" + ex.Message);
            }
        }

    }
}
