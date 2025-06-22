using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tvo.Dominio.Modelo.Abstracciones;

namespace tvo.Infraestructura.AccesoDatos.Repositorio
{
    public class OrderDetailsRepositoryImpl : RepositoryImpl<orderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepositoryImpl(db_tvoContext dbContext) : base(dbContext)
        {
        }
    }
}
