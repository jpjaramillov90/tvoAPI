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
    public class OrderDetailsServiceImpl : IOrderDetailsService
    {
        private readonly db_tvoContext _dbContext;
        private IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _orderDetailsRepository = new OrderDetailsRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(orderDetails entity)
        {
            await _orderDetailsRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderDetailsRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<orderDetails>> GetAllAsync()
        {
            return _orderDetailsRepository.GetAllAsync();
        }

        public Task<orderDetails> GetByIdAsync(int id)
        {
            return _orderDetailsRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(orderDetails entity)
        {
            await _orderDetailsRepository.UpdateAsync(entity);
        }
    }
}
