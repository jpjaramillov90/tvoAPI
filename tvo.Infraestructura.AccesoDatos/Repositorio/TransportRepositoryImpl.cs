using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Dominio.Modelo.Abstracciones;

namespace tvo.Infraestructura.AccesoDatos.Repositorio
{
    public class TransportRepositoryImpl : RepositoryImpl<transport>, ITransportRepository
    {
        public TransportRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
        }
    }
}
