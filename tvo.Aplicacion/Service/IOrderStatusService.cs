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
    public interface IOrderStatusService
    {
        [OperationContract]
        Task AddAsync(orderStatus entity);
        [OperationContract]
        Task UpdateAsync(orderStatus entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<orderStatus>> GetAllAsync();
        [OperationContract]
        Task<orderStatus> GetByIdAsync(int id);
    }
}
