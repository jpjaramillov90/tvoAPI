using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Aplicacion.Service;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.APIWeb.Controllers
{
    [ApiController]
    [Route("tvo/api/[controller]")]
    public class ClientController : Controller
    {
        private IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("ListClients")]
        public Task<IEnumerable<client>> GetAllAsync()
        {
            return _clientService.GetAllAsync();
        }

        [HttpGet("ListWithFirstName/{firstName}")]
        public Task<List<client>> SearchClient(string firstName)
        {
            return _clientService.SearchClient(firstName);
        }

        [HttpGet("ListClientAndStatus")]
        public async Task<List<ClientAndStatusDTO>> ListClientAndStatus()
        {
            return await _clientService.ListClientAndStatus();
        }

        [HttpPost("InsertClient")]
        public async Task<ActionResult> AddAsync([FromBody] client newClient)
        {
            try
            {
                await _clientService.AddAsync(newClient);
                return Ok("Cliente insertado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar cliente: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al insertar cliente: " + ex.Message);
            }
        }

        [HttpPut("UpdateClient")]
        public async Task<ActionResult> UpdateAsync([FromBody] client entity)
        {
            try
            {
                await _clientService.UpdateAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar cliente: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al actualizar cliente: " + ex.Message);
            }
        }

        [HttpDelete("DeleteClient/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                var client = await _clientService.GetByIdAsync(id);
                if (client == null)
                {
                    return NotFound("Cliente no encontrado.");
                }
                await _clientService.DeleteAsync(id);
                return Ok("Cliente eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar cliente: " + ex.Message);
                return StatusCode(500, "Error interno del servidor al eliminar cliente: " + ex.Message);
            }

        }
    } 
}
