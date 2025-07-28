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
    public interface IServicesService
    {
        [OperationContract]
        Task AddAsync(services entity);
        [OperationContract]
        Task UpdateAsync(services entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<services>> GetAllAsync();
        [OperationContract]
        Task<services> GetByIdAsync(int id);
        [OperationContract]
        Task<List<ServicePriceDTO>> GetServicesByMinPrice(decimal minPrice);
        [OperationContract]
        Task<List<GetServicesByWorkOrderDTO>> GetServicesByWorkOrder(int idWorkOrder);
    }
}
