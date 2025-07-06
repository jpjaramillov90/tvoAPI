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
    public interface IServicePriceHistoryService
    {
        [OperationContract]
        Task AddAsync(servicePriceHistory entity);
        [OperationContract]
        Task UpdateAsync(servicePriceHistory entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<servicePriceHistory>> GetAllAsync();
        [OperationContract]
        Task<servicePriceHistory> GetByIdAsync(int id);
    }
}
