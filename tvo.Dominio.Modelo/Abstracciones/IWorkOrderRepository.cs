using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.Dominio.Modelo.Abstracciones
{
    public interface IWorkOrderRepository : IRepository <workOrder>
    {
        Task<List<PendingWorkOrderDTO>> GetPendingWorkOrders();
        Task<List<EmployeeWorkOrdersDTO>> GetWorkOrdersByEmployeeId(int employeeId);
    }
}
