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
    public class SpecialtiesServiceImpl : ISpecialtiesService
    {
        private readonly db_tvoContext _dbContext;
        private ISpecialtiesRepository _specialtiesRepository;

        public SpecialtiesServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _specialtiesRepository = new SpecialtiesRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(specialties entity)
        {
            await _specialtiesRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _specialtiesRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<specialties>> GetAllAsync()
        {
            return _specialtiesRepository.GetAllAsync();
        }

        public Task<specialties> GetByIdAsync(int id)
        {
            return _specialtiesRepository.GetByIdAsync(id);
        }

        public Task<List<specialties>> ListSpecialties(string specialitie)
        {
            return _specialtiesRepository.ListSpecialties(specialitie);
        }

        public async Task UpdateAsync(specialties entity)
        {
            await _specialtiesRepository.UpdateAsync(entity);
        }
    }
}
