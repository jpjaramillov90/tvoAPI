using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Aplicacion.Service;
using tvo.Dominio.Modelo.Abstracciones;
using tvo.Infraestructura.AccesoDatos;
using tvo.Infraestructura.AccesoDatos.Repositorio;

namespace tvo.Aplicacion.ServiceImpl
{
    public class ServicesServiceImpl : IServicesService
    {
        private readonly db_tvoContext _dbContext;
        private IServicesRepository _servicesRepository;

        public ServicesServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _servicesRepository = new ServicesRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(services entity)
        {
            await _servicesRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _servicesRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<services>> GetAllAsync()
        {
            return _servicesRepository.GetAllAsync();
        }

        public Task<services> GetByIdAsync(int id)
        {
            return _servicesRepository.GetByIdAsync(id);
        }

        public async Task<List<ServicePriceDTO>> GetServicesByMinPrice(decimal minPrice)
        {
            return await _servicesRepository.GetServicesByMinPrice(minPrice);
        }

        public async Task UpdateAsync(services entity)
        {
            await _servicesRepository.UpdateAsync(entity);
        }
    }
}
