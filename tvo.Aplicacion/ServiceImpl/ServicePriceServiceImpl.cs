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
    public class ServicePriceServiceImpl : IServicePriceService
    {
        private readonly db_tvoContext _dbContext;
        private IServicePriceRepository _servicePriceRepository;

        public ServicePriceServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _servicePriceRepository = new ServicePriceRepositoryImpl(dbContext);
        }

        public async Task AddAsync(servicePrice entity)
        {
            await _servicePriceRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _servicePriceRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<servicePrice>> GetAllAsync()
        {
            return _servicePriceRepository.GetAllAsync();
        }

        public Task<servicePrice> GetByIdAsync(int id)
        {
            return _servicePriceRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(servicePrice entity)
        {
            await _servicePriceRepository.UpdateAsync(entity);
        }
    }
}
