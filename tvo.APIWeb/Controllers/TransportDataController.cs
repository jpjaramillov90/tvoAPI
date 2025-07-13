using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class TransportDataController : Controller
    {
        private readonly ITransportDataService _transportDataService;

        public TransportDataController(ITransportDataService transportDataService)
        {
            _transportDataService = transportDataService;
        }

        [HttpGet("ListTransportData")]
        public Task<IEnumerable<transportData>> GetAllAsync()
        {
            return _transportDataService.GetAllAsync();
        }

        [HttpGet("GetTransportDataWithClients")]
        public Task<List<TransportDataDTO>> GetTransportDataWithClients()
        {
            return _transportDataService.GetTransportDataWithClients();
        }

        [HttpPost("InsertTransportData")]
        public async Task<ActionResult> AddAsync([FromBody] transportData newTransportData)
        {
            try
            {
                await _transportDataService.AddAsync(newTransportData);
                return Ok("Datos de transporte registrados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar datos de transporte: " + ex.Message);
                return StatusCode(500, "Error en el servidor al insertar datos de transporte: " + ex.Message);
            }
        }  

        [HttpDelete("DeleteTransportData/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var transportData = await _transportDataService.GetByIdAsync(id);
                if (transportData == null)
                {
                    return NotFound("Datos de transporte no encontrados.");
                }
                await _transportDataService.DeleteAsync(id);
                return Ok("Datos de transporte eliminados exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar datos de transporte: " + ex.Message);
                return StatusCode(500, "Error en el servidor al eliminar datos de transporte: " + ex.Message);
            }
        }
    }
}
