using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tvo.Aplicacion.DTO.DTOs
{
    public class OrderDetailsDTO
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string WorkOrderDescription { get; set; }
        public string ServiceDescription { get; set; }
        public string OrderStatus { get; set; }
    }
}
