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
    public interface IWorkOrderService
    {
        [OperationContract]
        Task AddAsync(workOrder entity);
        [OperationContract]
        Task UpdateAsync(workOrder entity);
        [OperationContract]
        Task DeleteAsync(int id);
        [OperationContract]
        Task<IEnumerable<workOrder>> GetAllAsync();
        [OperationContract]
        Task<workOrder> GetByIdAsync(int id);
        [OperationContract]
        Task<List<PendingWorkOrderDTO>> GetPendingWorkOrders();
        [OperationContract]
        Task<List<EmployeeWorkOrdersDTO>> GetWorkOrdersByEmployeeId(int employeeId);
    }
}
