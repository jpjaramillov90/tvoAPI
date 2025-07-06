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
    public class TransportServiceImpl : ITransportService
    {
        private readonly db_tvoContext _dbContext;
        private ITransportRepository _transportRepository;

        public TransportServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _transportRepository = new TransportRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(transport entity)
        {
            await _transportRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _transportRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<transport>> GetAllAsync()
        {
            return _transportRepository.GetAllAsync();
        }

        public Task<transport> GetByIdAsync(int id)
        {
            return _transportRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(transport entity)
        {
            await _transportRepository.UpdateAsync(entity);
        }
    }
}
