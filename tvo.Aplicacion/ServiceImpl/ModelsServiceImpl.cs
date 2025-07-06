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
    public class ModelsServiceImpl : IModelsService
    {
        private readonly db_tvoContext _dbContext;
        private IModelsRepository _modelsRepository;

        public ModelsServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _modelsRepository = new ModelsRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(models entity)
        {
            await _modelsRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _modelsRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<models>> GetAllAsync()
        {
            return _modelsRepository.GetAllAsync();
        }

        public Task<models> GetByIdAsync(int id)
        {
            return _modelsRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(models entity)
        {
            await _modelsRepository.UpdateAsync(entity);
        }
    }
}
