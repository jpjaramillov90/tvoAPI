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
    public class ClientStatusServiceImpl : IClientStatusService
    {
        private readonly db_tvoContext _dbContext;
        private IClientStatusRepository _clientStatusRepository;

        public ClientStatusServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _clientStatusRepository = new ClientStatusRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(clientStatus entity)
        {
            await _clientStatusRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientStatusRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<clientStatus>> GetAllAsync()
        {
            return _clientStatusRepository.GetAllAsync();
        }

        public Task<clientStatus> GetByIdAsync(int id)
        {
            return _clientStatusRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(clientStatus entity)
        {
            await _clientStatusRepository.UpdateAsync(entity);
        }
    }
}
