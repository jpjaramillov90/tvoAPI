using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Dominio.Modelo.Abstracciones;

namespace tvo.Infraestructura.AccesoDatos.Repositorio
{
    public class RepositoryImpl<T> : IRepository<T> where T : class
    {
        private readonly db_tvoContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public RepositoryImpl(db_tvoContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity); //inserta en las tablas
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error no se pudo insertar los datos, " + ex.Message);
            }
        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var entidad = await GetByIdAsync(id);
                _dbSet.Remove(entidad); //elimina el registro con el ID
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error no se pudo eliminar el dato, " + ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync(); //lista todos los datos
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron listar los datos, " + ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id); //buscar las tablas por id --siempre que sean números
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudieron listar con el ID especificado, " + ex.Message);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity); 
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error no se pudo insertar los datos, " + ex.Message);
            }
        }
    }
}
