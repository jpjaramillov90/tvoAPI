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
    public class ServicePriceHistoryServiceImpl : IServicePriceHistoryService
    {
        private readonly db_tvoContext _dbContext;
        private IServicePriceHistoryRepository _servicePriceHistoryRepository;

        public ServicePriceHistoryServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _servicePriceHistoryRepository = new ServicePriceHistoryRepositoryImpl(dbContext);
        }

        public async Task AddAsync(servicePriceHistory entity)
        {
            await _servicePriceHistoryRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _servicePriceHistoryRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<servicePriceHistory>> GetAllAsync()
        {
            return _servicePriceHistoryRepository.GetAllAsync();
        }

        public Task<servicePriceHistory> GetByIdAsync(int id)
        {
            return _servicePriceHistoryRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(servicePriceHistory entity)
        {
            await _servicePriceHistoryRepository.UpdateAsync(entity);
        }
    }
}
