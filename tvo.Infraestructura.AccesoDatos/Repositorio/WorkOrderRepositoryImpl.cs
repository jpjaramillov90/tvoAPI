using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Dominio.Modelo.Abstracciones;

namespace tvo.Infraestructura.AccesoDatos.Repositorio
{
    public class WorkOrderRepositoryImpl : RepositoryImpl<workOrder>, IWorkOrderRepository
    {
        private readonly db_tvoContext _dbContext;
        public WorkOrderRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PendingWorkOrderDTO>> GetPendingWorkOrders()
        {
            try
            {
                var pendingOrders = await(from wo in _dbContext.workOrder
                                          join os in _dbContext.orderStatus on wo.idOrderStatus equals os.idOrderStatus
                                          join e in _dbContext.employee on wo.idEmployee equals e.idEmployee
                                          join s in _dbContext.specialties on e.idSpecialties equals s.idSpecialties
                                          where os.orderStatus1 == "Pendiente"
                                          select new PendingWorkOrderDTO
                                          {
                                              EmployeeFirstName = e.firstName,
                                              EmployeeLastName = e.lastName,
                                              Specialty = s.specialty,
                                              WorkOrderDescription = wo.descriptionWO,
                                              OrderStatus = os.orderStatus1
                                          }).ToListAsync();
                return pendingOrders;

            }
            catch (Exception ex) { 
                throw new Exception("No se pueden mostrar las ordenes pendientes: " + ex.Message);
            }
        }

        public async Task<List<EmployeeWorkOrdersDTO>> GetWorkOrdersByEmployeeId(int employeeId)
        {
            try
            {
                var orders = await (from wo in _dbContext.workOrder
                                    join os in _dbContext.orderStatus on wo.idOrderStatus equals os.idOrderStatus
                                    join e in _dbContext.employee on wo.idEmployee equals e.idEmployee
                                    join s in _dbContext.specialties on e.idSpecialties equals s.idSpecialties
                                    where e.idEmployee == employeeId
                                    select new EmployeeWorkOrdersDTO
                                    {
                                        EmployeeFirstName = e.firstName,
                                        EmployeeLastName = e.lastName,
                                        Specialty = s.specialty,
                                        WorkOrderDescription = wo.descriptionWO,
                                        OrderStatus = os.orderStatus1
                                    }).ToListAsync();
                return orders;

            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden mostrar las ordenes pendientes: " + ex.Message);
            }
        }
    }
}
