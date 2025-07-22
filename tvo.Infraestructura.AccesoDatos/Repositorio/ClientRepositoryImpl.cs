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
    public class ClientRepositoryImpl : RepositoryImpl<client>, IClientRepository
    {
        private readonly db_tvoContext _dbContext;
        public ClientRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<ClientAndStatusDTO>> ListClientAndStatus()
        {
            try
            {
                var clientAndStatus = await (from c in _dbContext.client
                                             join cs in _dbContext.clientStatus on c.idClientStatus equals cs.idClientStatus
                                             select new ClientAndStatusDTO
                                             {
                                                 nui = c.nui,
                                                 firstname = c.firstName,
                                                 lastname = c.lastName,
                                                 clientStatus = cs.clientStatus1
                                             }).ToListAsync();
                return clientAndStatus;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los clientes y su estado: " + ex.Message);
            }
        }

        public async Task<LoginDTO> LoginView(string mail, string password)
        {
            try
            {
                var loginResult = await (from tmpLogin in _dbContext.client
                                         where tmpLogin.mail == mail && tmpLogin.passwordClient == password
                                         select new LoginDTO
                                         {
                                             mail = tmpLogin.mail,
                                             password = tmpLogin.passwordClient,
                                         }).FirstOrDefaultAsync();

                return loginResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el inicio de sesión: " + ex.Message);
            }
        }

        public Task<List<client>> SearchClient(string firstName)
        {
            try
            {
                var result = from tmpClient in _dbContext.client
                             where tmpClient.firstName == firstName
                             select tmpClient;
                return result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el cliente por nombre: " + ex.Message);
            }
        }
    }
}
