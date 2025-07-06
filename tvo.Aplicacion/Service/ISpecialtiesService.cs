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
    public interface ISpecialtiesService
    {
        [OperationContract]
        Task AddAsync(specialties entity);
        [OperationContract]
        Task UpdateAsync(specialties entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<specialties>> GetAllAsync();
        [OperationContract]
        Task<specialties> GetByIdAsync(int id);
    }
}
