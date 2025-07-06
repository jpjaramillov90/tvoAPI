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
    public interface ITransportService
    {
        [OperationContract]
        Task AddAsync(transport entity);
        [OperationContract]
        Task UpdateAsync(transport entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<transport>> GetAllAsync();
        [OperationContract]
        Task<transport> GetByIdAsync(int id);
    }
}
