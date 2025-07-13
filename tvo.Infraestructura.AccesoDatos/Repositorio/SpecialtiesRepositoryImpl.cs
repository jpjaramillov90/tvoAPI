using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Dominio.Modelo.Abstracciones;

namespace tvo.Infraestructura.AccesoDatos.Repositorio
{
    public class SpecialtiesRepositoryImpl : RepositoryImpl<specialties>, ISpecialtiesRepository
    {
        private readonly db_tvoContext _dbContext;
        public SpecialtiesRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<specialties>> ListSpecialties(string specialitie)
        {
            try
            {
                var result = from tmp_specialties in _dbContext.specialties
                             where tmp_specialties.specialty == specialitie
                             select tmp_specialties;
                return result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar las especialidades: " + ex.Message);
            }
        }
    }
}
