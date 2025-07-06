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
    public class OrderStatusServiceImpl : IOrderStatusService
    {
        private readonly db_tvoContext _dbContext;
        private IOrderStatusRepository _orderStatusRepository;

        public OrderStatusServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _orderStatusRepository = new OrderStatusRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(orderStatus entity)
        {
            await _orderStatusRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderStatusRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<orderStatus>> GetAllAsync()
        {
            return _orderStatusRepository.GetAllAsync();
        }

        public Task<orderStatus> GetByIdAsync(int id)
        {
            return _orderStatusRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(orderStatus entity)
        {
            await _orderStatusRepository.UpdateAsync(entity);
        }
    }
}
