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
    public interface IModelsService
    {
        [OperationContract]
        Task AddAsync(models entity);
        [OperationContract]
        Task UpdateAsync(models entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<models>> GetAllAsync();
        [OperationContract]
        Task<models> GetByIdAsync(int id);
    }
}
