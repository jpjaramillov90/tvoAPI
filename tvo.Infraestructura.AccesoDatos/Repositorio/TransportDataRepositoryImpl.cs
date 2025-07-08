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
    public class TransportDataRepositoryImpl : RepositoryImpl<transportData>, ITransportDataRepository
    {
        private readonly db_tvoContext _dbContext;
        public TransportDataRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<TransportDataDTO>> GetTransportDataWithClients()
        {
            try
            {
                var join = await (from td in _dbContext.transportData
                           join c in _dbContext.client on td.idClient equals c.idClient
                           join t in _dbContext.transport on td.idTransport equals t.idTransport
                           select new TransportDataDTO
                           {
                               Nui = c.nui,
                               FirstName = c.firstName,
                               LastName = c.lastName,
                               TypeTransport = t.typeTransport,
                               Plate = td.plate
                           }).ToListAsync();
                return join;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el tipo de transporte de cada cliente: " + ex.Message);
            }
        }
    }
}
