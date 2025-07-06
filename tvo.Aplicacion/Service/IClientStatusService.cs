using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.Aplicacion.Service
{
    [ServiceContract]
    public interface IClientStatusService
    {
        [OperationContract]
        Task AddAsync(clientStatus entity);
        [OperationContract]
        Task UpdateAsync(clientStatus entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<clientStatus>> GetAllAsync();
        [OperationContract]
        Task<clientStatus> GetByIdAsync(int id);
    }
}
