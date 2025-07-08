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
    public interface ICooperativeService
    {
        [OperationContract]
        Task AddAsync(cooperative entity);
        [OperationContract]
        Task UpdateAsync(cooperative entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<cooperative>> GetAllAsync();
        [OperationContract]
        Task<cooperative> GetByIdAsync(int id);
        [OperationContract]
        Task<int> CountCooperativesByName(string nameCooperative);
    }
}
