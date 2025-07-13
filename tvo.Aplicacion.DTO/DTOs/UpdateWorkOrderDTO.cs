using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvo.Aplicacion.DTO.DTOs
{
    public class UpdateWorkOrderDTO
    {
        public int idWorkOrder { get; set; }
        public int? idEmployee { get; set; }
        public int? idOrderStatus { get; set; }
        public string descriptionWO { get; set; }
        public DateOnly expires { get; set; }

    }
}
