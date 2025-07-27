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

        public async Task<TotalBudgetDTO> GetTotalBudgetByidwo(int idwo)
        {
            try
            {
                var result = await (from c in _dbContext.client
                                    join td in _dbContext.transportData on c.idClient equals td.idClient
                                    join bu in _dbContext.budget on td.idTransportData equals bu.idTransportData
                                    join wo in _dbContext.workOrder on bu.idWorkOrder equals wo.idWorkOrder
                                    join od in _dbContext.orderDetails on wo.idWorkOrder equals od.idWorkOrder
                                    join s in _dbContext.services on od.idService equals s.idService
                                    join sp in _dbContext.servicePrice on s.idService equals sp.idService
                                    join os in _dbContext.orderStatus on wo.idOrderStatus equals os.idOrderStatus
                                    where wo.idWorkOrder == idwo
                                    group sp.price by wo.idWorkOrder into g
                                    select new TotalBudgetDTO
                                    {
                                        totalBudget = g.Sum(),
                                        idWorkOrder = g.Key.ToString()
                                    }).FirstOrDefaultAsync();

                return result ?? new TotalBudgetDTO
                {
                    totalBudget = 0,
                    idWorkOrder = idwo.ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al calcular el presupuesto total para la Orden de Trabajo {idwo}: {ex.Message}", ex);
            }
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

        public async Task<List<SearchBudgetDTO>> SearchBudgetWithidwo(int idwo)
        {
            try
            {
                var budgets = await (from c in _dbContext.client
                                     join td in _dbContext.transportData on c.idClient equals td.idClient
                                     join b in _dbContext.budget on td.idTransportData equals b.idTransportData
                                     join wo in _dbContext.workOrder on b.idWorkOrder equals wo.idWorkOrder
                                     join os in _dbContext.orderStatus on wo.idOrderStatus equals os.idOrderStatus
                                     join od in _dbContext.orderDetails on wo.idWorkOrder equals od.idWorkOrder
                                     join s in _dbContext.services on od.idService equals s.idService
                                     join sp in _dbContext.servicePrice on s.idService equals sp.idService
                                     join br in _dbContext.brands on b.idBrands equals br.idBrands into brandJoin
                                     from brand in brandJoin.DefaultIfEmpty()
                                     where wo.idWorkOrder == idwo
                                     select new SearchBudgetDTO
                                     {
                                         idWorkOrder = wo.idWorkOrder,
                                         orderStatus = os.orderStatus1,
                                         idOrderDetails = od.idOrderDetails,
                                         idService = s.idService,
                                         descriptionServices = s.descriptionServices,
                                         price = sp.price,
                                         expires = wo.expires,
                                         clientNui = c.nui,
                                         clientName = c.firstName + " " + c.lastName,
                                         vehiclePlate = td.plate,
                                         vehicleBrand = brand != null ? brand.brand : "No especificado",
                                         vehicleModel = (brand != null && _dbContext.models.Any(m => m.idBrands == brand.idBrands))
                                                        ? _dbContext.models
                                                                      .Where(m => m.idBrands == brand.idBrands)
                                                                      .OrderBy(m => m.models1)
                                                                      .Select(m => m.models1)
                                                                      .FirstOrDefault()
                                                        : "No especificado"
                                     }).ToListAsync();

                return budgets;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden obtener los presupuestos: " + ex.Message);
            }
        }
    }
}
