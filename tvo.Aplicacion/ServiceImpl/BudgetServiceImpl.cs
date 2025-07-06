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
    public class BudgetServiceImpl : IBudgetService
    {
        private readonly db_tvoContext _dbContext;
        private IBudgetRepository _budgetRepository;

        public BudgetServiceImpl(db_tvoContext dbContext)
        {
           this._dbContext = dbContext;
            _budgetRepository = new BudgetRepositoryImpl(_dbContext);
        }

        public async Task AddAsync(budget entity)
        {
            await _budgetRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _budgetRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<budget>> GetAllAsync()
        {
            return _budgetRepository.GetAllAsync();
        }

        public Task<budget> GetByIdAsync(int id)
        {
            return _budgetRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(budget entity)
        {
            await _budgetRepository.UpdateAsync(entity);
        }
    }
}
