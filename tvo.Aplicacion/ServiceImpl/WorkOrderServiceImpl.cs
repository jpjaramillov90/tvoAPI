using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.Service;
using tvo.Dominio.Modelo.Abstracciones;
using tvo.Infraestructura.AccesoDatos;
using tvo.Infraestructura.AccesoDatos.Repositorio;

namespace tvo.Aplicacion.ServiceImpl
{
    public class WorkOrderServiceImpl : IWorkOrderService
    {
        private readonly db_tvoContext _dbContext;
        private IWorkOrderRepository _workOrderRepository;

        public WorkOrderServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _workOrderRepository = new WorkOrderRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(workOrder entity)
        {
            await _workOrderRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _workOrderRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<workOrder>> GetAllAsync()
        {
            return _workOrderRepository.GetAllAsync();
        }

        public Task<workOrder> GetByIdAsync(int id)
        {
            return _workOrderRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(workOrder entity)
        {
            await _workOrderRepository.UpdateAsync(entity);
        }
    }
}
