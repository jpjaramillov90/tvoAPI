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
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly db_tvoContext _dbContext;
        private IEmployeeRepository _employeeRepository;

        public EmployeeServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _employeeRepository = new EmployeeRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(employee entity)
        {
            await _employeeRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<employee>> GetAllAsync()
        {
            return _employeeRepository.GetAllAsync();
        }

        public Task<employee> GetByIdAsync(int id)
        {
            return _employeeRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(employee entity)
        {
            await _employeeRepository.UpdateAsync(entity);
        }
    }
}
