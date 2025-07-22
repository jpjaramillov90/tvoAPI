using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.Dominio.Modelo.Abstracciones
{
    public interface IClientRepository : IRepository<client>
    {
        Task<List<client>> SearchClient(String firstName);

        Task<List<ClientAndStatusDTO>> ListClientAndStatus();

        Task<LoginDTO> LoginView(string mail, string password);
    }
}
