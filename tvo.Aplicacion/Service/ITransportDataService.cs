using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.Aplicacion.Service
{
    [ServiceContract]
    public interface ITransportDataService
    {
        [OperationContract]
        Task AddAsync(transportData entity);
        [OperationContract]
        Task UpdateAsync(transportData entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<transportData>> GetAllAsync();
        [OperationContract]
        Task<transportData> GetByIdAsync(int id);
        [OperationContract]
        Task<List<TransportDataDTO>> GetTransportDataWithClients();
        [OperationContract]
        Task<bool> ChassisExists(string chassis);
    }
}
