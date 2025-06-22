using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvo.Dominio.Modelo.Abstracciones
{
    public interface IRepository <T> where  T : class
    {
        Task AddAsync(T entity); // insetar
        Task UpdateAsync(T entity); // actualizar
        Task DeleteAsync(int id); // eliminar
        Task<IEnumerable<T>> GetAllAsync(); // listar (select * from)
        Task<T> GetByIdAsync(int id); // buscar por id
    }
}
