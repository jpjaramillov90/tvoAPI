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
    public class BrandsServiceImpl : IBrandsService
    {
        private readonly db_tvoContext _dbContext;
        private IBrandsRepository _brandsRepository;

        public BrandsServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _brandsRepository = new BrandsRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(brands entity)
        {
            await _brandsRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _brandsRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<brands>> GetAllAsync()
        {
            return _brandsRepository.GetAllAsync();
        }

        public Task<brands> GetByIdAsync(int id)
        {
            return _brandsRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(brands entity)
        {
            await _brandsRepository.UpdateAsync(entity);  
        }
    }
}
