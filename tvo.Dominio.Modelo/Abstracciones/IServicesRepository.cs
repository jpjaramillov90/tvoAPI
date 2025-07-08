using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Aplicacion.DTO.DTOs;
using tvo.Infraestructura.AccesoDatos;

namespace tvo.Dominio.Modelo.Abstracciones
{
    public interface IServicesRepository : IRepository<services>
    {
        Task<List<ServicePriceDTO>> GetServicesByMinPrice(decimal minPrice);
    }
}
