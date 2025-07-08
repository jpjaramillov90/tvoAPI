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
    public class OrderDetailsRepositoryImpl : RepositoryImpl<orderDetails>, IOrderDetailsRepository
    {
        private readonly db_tvoContext _dbContext;
        public OrderDetailsRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<OrderDetailsDTO>> GetOrderDetailsWithRelatedData()
        {
            try
            {
                var result = await (from od in _dbContext.orderDetails
                             join wo in _dbContext.workOrder on od.idWorkOrder equals wo.idWorkOrder
                             join s in _dbContext.services on od.idService equals s.idService
                             join os in _dbContext.orderStatus on wo.idOrderStatus equals os.idOrderStatus
                             join e in _dbContext.employee on wo.idEmployee equals e.idEmployee
                             select new OrderDetailsDTO
                             {
                                 EmployeeFirstName = e.firstName,
                                 EmployeeLastName = e.lastName,
                                 WorkOrderDescription = wo.descriptionWO,
                                 ServiceDescription = s.descriptionServices,
                                 OrderStatus = os.orderStatus1
                             }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("NO se pueden listar las ordenes de trabajo: " + ex.Message);
            }
        }
    }
}
