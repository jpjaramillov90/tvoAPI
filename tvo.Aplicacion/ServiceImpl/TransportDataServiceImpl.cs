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
    public class TransportDataServiceImpl : ITransportDataService
    {
        private readonly db_tvoContext _dbContext;
        private ITransportDataRepository _transportDataRepository;

        public TransportDataServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _transportDataRepository = new TransportDataRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(transportData entity)
        {
            await _transportDataRepository.AddAsync(entity);
        }

        public async Task<bool> ChassisExists(string chassis)
        {
            return await _transportDataRepository.ChassisExists(chassis);
        }

        public async Task DeleteAsync(int id)
        {
            await _transportDataRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<transportData>> GetAllAsync()
        {
            return _transportDataRepository.GetAllAsync();
        }

        public Task<transportData> GetByIdAsync(int id)
        {
            return _transportDataRepository.GetByIdAsync(id);
        }

        public async Task<List<TransportDataDTO>> GetTransportDataWithClients()
        {
            return await _transportDataRepository.GetTransportDataWithClients();
        }

        public async Task UpdateAsync(transportData entity)
        {
            await _transportDataRepository.UpdateAsync(entity);
        }
    }
}
