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
    public interface IBudgetService
    {
        [OperationContract]
        Task AddAsync(budget entity);
        [OperationContract]
        Task UpdateAsync(budget entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<budget>> GetAllAsync();
        [OperationContract]
        Task<budget> GetByIdAsync(int id);
    }
}
