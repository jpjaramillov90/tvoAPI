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
    public interface IServicePriceService
    {
        [OperationContract]
        Task AddAsync(servicePrice entity);
        [OperationContract]
        Task UpdateAsync(servicePrice entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<servicePrice>> GetAllAsync();
        [OperationContract]
        Task<servicePrice> GetByIdAsync(int id);
    }
}
