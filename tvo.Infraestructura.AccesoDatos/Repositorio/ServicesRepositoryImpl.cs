using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Dominio.Modelo.Abstracciones;

namespace tvo.Infraestructura.AccesoDatos.Repositorio
{
    public class ServicesRepositoryImpl : RepositoryImpl<services>, IServicesRepository
    {
        private readonly db_tvoContext _dbContext;
        public ServicesRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<ServicePriceDTO>> GetServicesByMinPrice(decimal minPrice)
        {
            try
            {
                var services = await (from s in _dbContext.services
                                      join sp in _dbContext.servicePrice on s.idService equals sp.idService
                                      where sp.price > minPrice
                                      orderby sp.price descending
                                      select new ServicePriceDTO
                                      {
                                          ServiceDescription = s.descriptionServices,
                                          Price = sp.price
                                      }).ToListAsync();
                return services;
            }
            catch (Exception ex)
            {
                throw new Exception("No se ver los servicios con más de el valor indicado: " + ex.Message);
            }
        }
    }
}
