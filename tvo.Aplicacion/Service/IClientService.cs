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
    public interface IClientService
    {
        [OperationContract]
        Task AddAsync(client entity);
        [OperationContract]
        Task UpdateAsync(client entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<client>> GetAllAsync();
        [OperationContract]
        Task<client> GetByIdAsync(int id);
        [OperationContract]
        Task<List<client>> SearchClient(string firstName);
        [OperationContract]
        Task<List<ClientAndStatusDTO>> ListClientAndStatus();
        [OperationContract]
        Task<LoginDTO> LoginView(string mail, string password);
    }
}
