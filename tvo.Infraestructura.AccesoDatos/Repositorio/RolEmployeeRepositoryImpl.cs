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
    public class RolEmployeeRepositoryImpl : RepositoryImpl<rolEmployee>, IRolEmployeeRepository
    {
        private readonly db_tvoContext _dbContext;
        public RolEmployeeRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
            this._dbContext=dbContext;
        }

        public async Task<List<RolEmployeeServicesDTO>> GetRolesWithServices()
        {
            try
            {
                var rolesWithServices = await (from r in _dbContext.rolEmployee
                                              join s in _dbContext.services on r.idRolEmployee equals s.idService
                                              select new RolEmployeeServicesDTO
                                              {
                                                  RoleDescription = r.descriptionRol,
                                                  ServiceDescription = s.descriptionServices
                                              }).ToListAsync();
                return rolesWithServices;

            }
            catch (Exception ex)
            {
                throw new Exception("No se pueden mostrar las ordenes pendientes: " + ex.Message);
            }
        }
    }
}
