using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.Aplicacion.Service
{
    [ServiceContract]
    public interface IOrderDetailsService
    {
        [OperationContract]
        Task AddAsync(orderDetails entity);
        [OperationContract]
        Task UpdateAsync(orderDetails entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<orderDetails>> GetAllAsync();
        [OperationContract]
        Task<orderDetails> GetByIdAsync(int id);
        [OperationContract]
        Task<List<OrderDetailsDTO>> GetOrderDetailsWithRelatedData();
    }
}
