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
    public class RolEmployeeServiceImpl : IRolEmployeeService
    {
        private readonly db_tvoContext _dbContext;
        private IRolEmployeeRepository _employeeRepository;

        public RolEmployeeServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _employeeRepository = new RolEmployeeRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(rolEmployee entity)
        {
            await _employeeRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<rolEmployee>> GetAllAsync()
        {
            return _employeeRepository.GetAllAsync();
        }

        public Task<rolEmployee> GetByIdAsync(int id)
        {
            return _employeeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(rolEmployee entity)
        {
            await _employeeRepository.UpdateAsync(entity);
        }
    }
}
