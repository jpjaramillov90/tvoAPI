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
    public interface IRolEmployeeService
    {
        [OperationContract]
        Task AddAsync(rolEmployee entity);
        [OperationContract]
        Task UpdateAsync(rolEmployee entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<rolEmployee>> GetAllAsync();
        [OperationContract]
        Task<rolEmployee> GetByIdAsync(int id);
    }
}
