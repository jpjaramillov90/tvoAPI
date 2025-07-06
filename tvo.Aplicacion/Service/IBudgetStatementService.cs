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
    public interface IBudgetStatementService
    {
        [OperationContract]
        Task AddAsync(budgetStatement entity);
        [OperationContract]
        Task UpdateAsync(budgetStatement entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<budgetStatement>> GetAllAsync();
        [OperationContract]
        Task<budgetStatement> GetByIdAsync(int id);
    }
}
