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
    public interface IEmployeeService
    {
        [OperationContract]
        Task AddAsync(employee entity);
        [OperationContract]
        Task UpdateAsync(employee entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<employee>> GetAllAsync();
        [OperationContract]
        Task<employee> GetByIdAsync(int id);
    }
}
