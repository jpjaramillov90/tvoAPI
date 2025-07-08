using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Dominio.Modelo.Abstracciones;

namespace tvo.Infraestructura.AccesoDatos.Repositorio
{
    public class CooperativeRepositoryImpl : RepositoryImpl<cooperative>, ICooperativeRepository
    {
        private readonly db_tvoContext _dbContext;
        public CooperativeRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<int> CountCooperativesByName(string nameCooperative)
        {
            try
            {
                var result = from tmpCount in _dbContext.cooperative
                             where tmpCount.nameCooperative.Contains(nameCooperative)
                             select tmpCount;

                return result.CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar las cooperativas: " + ex.Message);
            }
        }
    }
}
