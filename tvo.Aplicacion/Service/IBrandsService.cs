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
    public interface IBrandsService
    {
        [OperationContract]
        Task AddAsync(brands entity); // insetar
        [OperationContract]
        Task UpdateAsync(brands entity); // actualizar
        [OperationContract]
        Task DeleteAsync(int id); // eliminar
        [OperationContract]
        Task<IEnumerable<brands>> GetAllAsync(); // listar (select * from)
        [OperationContract]
        Task<brands> GetByIdAsync(int id); // buscar por id
    }
}
