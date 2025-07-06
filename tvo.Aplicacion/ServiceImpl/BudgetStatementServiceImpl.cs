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
    public class BudgetStatementServiceImpl : IBudgetStatementService
    {
        private readonly db_tvoContext _dbContext;
        private IBudgetStatementRepository _budgetStatementRepository;

        public BudgetStatementServiceImpl(db_tvoContext dbContext)
        {
            this._dbContext = dbContext;
            _budgetStatementRepository = new BudgetStatementRepositoryImpl(dbContext);
        }

        public async Task AddAsync(budgetStatement entity)
        {
            await _budgetStatementRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _budgetStatementRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<budgetStatement>> GetAllAsync()
        {
            return _budgetStatementRepository.GetAllAsync();
        }

        public Task<budgetStatement> GetByIdAsync(int id)
        {
            return _budgetStatementRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(budgetStatement entity)
        {
            await _budgetStatementRepository.UpdateAsync(entity);
        }
    }
}
