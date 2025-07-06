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
    public class ClientServiceImpl : IClientService
    {
        private readonly db_tvoContext _dbContext;
        private IClientRepository _clientRepository;

        public ClientServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _clientRepository = new ClientRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(client entity)
        {
            await _clientRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<client>> GetAllAsync()
        {
            return _clientRepository.GetAllAsync();
        }

        public Task<client> GetByIdAsync(int id)
        {
            return _clientRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(client entity)
        {
            await _clientRepository.UpdateAsync(entity);
        }
    }
}
