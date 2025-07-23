using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.Dominio.Modelo.Abstracciones
{
    public interface ITransportDataRepository : IRepository<transportData>
    {
        Task<List<TransportDataDTO>> GetTransportDataWithClients();
        Task<bool> ChassisExists(string chassis);
    }
}
