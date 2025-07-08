using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.Threading.Tasks;
using tvo.Aplicacion.Service;
using tvo.Aplicacion.ServiceImpl;
using tvo.Infraestructura.AccesoDatos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test_tvoAPI
{
    public class Tests
    {
        private db_tvoContext _dbContext;
        private IClientStatusService _clientStatus;
        private ISpecialtiesService _specialties;
        private IClientService _client;
        private ICooperativeService _cooperative;
        private ITransportDataService _transportDataService;
        private IOrderDetailsService _orderDetailsService;
        private IServicesService _services;
        private IWorkOrderService _workOrderService;
        private IRolEmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<db_tvoContext>()
                .UseSqlServer("Data Source=JOAOJV;Initial Catalog=db_tvo;Persist Security Info=True;User ID=sa;Password=Angul4r23;TrustServerCertificate=True;")
                .Options;
            _dbContext = new db_tvoContext(options);
            _clientStatus = new ClientStatusServiceImpl(_dbContext);
            _specialties = new SpecialtiesServiceImpl(_dbContext);
            _client = new ClientServiceImpl(_dbContext);
            _cooperative = new CooperativeServiceImpl(_dbContext);
            _transportDataService = new TransportDataServiceImpl(_dbContext);
            _orderDetailsService = new OrderDetailsServiceImpl(_dbContext);
            _services = new ServicesServiceImpl(_dbContext);
            _workOrderService = new WorkOrderServiceImpl(_dbContext);
            _employeeService = new RolEmployeeServiceImpl(_dbContext);
        }

        [Test]
        public async Task Test1()
        {
            //var clientStatus = new clientStatus { clientStatus1 = "Moroso" };
            //await _clientStatus.AddAsync(clientStatus);
            //var result = _clientStatus.GetByIdAsync(2);
            //Console.WriteLine(result);
            //Assert.Pass();
            //var result = _specialties.ListSpecialties();
            //var result = await _client.SearchClient("Luis");
            /*var result = _cooperative.CountCooperativesByName("Granada");
            Console.WriteLine(result);*/

            /*
            var joinTD = await _transportDataService.GetTransportDataWithClients();
            Console.WriteLine("Resultados de la consulta:");
            Console.WriteLine($"Total de registros: {joinTD.Count}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| NUI       | Nombre          | Tipo       | Placa   |");
            Console.WriteLine("--------------------------------------------------");

            foreach (var item in joinTD)
            {
                Console.WriteLine($"| {item.Nui,-9} | {item.FirstName + " " + item.LastName,-15} | {item.TypeTransport,-10} | {item.Plate,-7} |");
            }
            Console.WriteLine("--------------------------------------------------");

            */

            /*var clientAndStatus = await _client.ListClientAndStatus();
            Console.WriteLine("Resultados de la consulta de clientes y estados:");
            Console.WriteLine($"Total de registros: {clientAndStatus.Count}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| NUI        | Nombre Completo      | Estado      |");
            Console.WriteLine("--------------------------------------------------");

            foreach (var item in clientAndStatus)
            {
                Console.WriteLine($"| {item.nui,-13} | {item.firstname + " " + item.lastname,-20} | {item.clientStatus,-11} |");
            }
            Console.WriteLine("--------------------------------------------------");
            */

            /*var od = await _orderDetailsService.GetOrderDetailsWithRelatedData();
            Console.WriteLine("Resultados de la consulta de órdenes de trabajo:");
            Console.WriteLine($"Total de registros: {od.Count}");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("| Empleado           | Descripción Orden | Servicio           | Estado        |");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (var item in od)
            {
                Console.WriteLine($"| {item.EmployeeFirstName + " " + item.EmployeeLastName,-18} " +
                                $"| {item.WorkOrderDescription,-18} " +
                                $"| {item.ServiceDescription,-18} " +
                                $"| {item.OrderStatus,-13} |");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");*/
            /*
            decimal minPrice = 400.00m;
            var servicePrice = await _services.GetServicesByMinPrice(minPrice);
            Console.WriteLine("\nServicios con precio mayor a $" + minPrice);
            Console.WriteLine($"Total de registros: {servicePrice.Count}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("| Servicio                | Precio      |");
            Console.WriteLine("------------------------------------------");

            foreach (var item in servicePrice)
            {
                Console.WriteLine($"| {item.ServiceDescription,-24} | {item.Price,10:C2} |");
            }
            Console.WriteLine("------------------------------------------");*/

            /*
            var pendingOrders = await _workOrderService.GetPendingWorkOrders();
            Console.WriteLine("\nÓrdenes de Trabajo Pendientes:");
            Console.WriteLine($"Total de registros: {pendingOrders.Count}");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("| Empleado            | Especialidad      | Descripción Orden      | Estado      |");
            Console.WriteLine("------------------------------------------------------------------------------------------");

            foreach (var item in pendingOrders)
            {
                Console.WriteLine($"| {item.EmployeeFirstName + " " + item.EmployeeLastName,-20} " +
                                $"| {item.Specialty,-18} " +
                                $"| {item.WorkOrderDescription,-22} " +
                                $"| {item.OrderStatus,-11} |");
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");*/

            /*
            int employeeId = 10;
            var employeeWorkOrders = await _workOrderService.GetWorkOrdersByEmployeeId(employeeId);
            Console.WriteLine($"\nÓrdenes del Empleado ID: {employeeId}");
            Console.WriteLine($"Total de registros: {employeeWorkOrders.Count}");

            if (employeeWorkOrders.Any())
            {
                Console.WriteLine($"Empleado: {employeeWorkOrders[0].EmployeeFirstName} {employeeWorkOrders[0].EmployeeLastName}");
                Console.WriteLine($"Especialidad: {employeeWorkOrders[0].Specialty}");
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("| Descripción Orden      | Estado        |");
            Console.WriteLine("------------------------------------------");

            foreach (var item in employeeWorkOrders)
            {
                Console.WriteLine($"| {item.WorkOrderDescription,-22} | {item.OrderStatus,-13} |");
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");*/

            var employeeService = await _employeeService.GetRolesWithServices();
            Console.WriteLine("\nRelación de Roles con Servicios:");
            Console.WriteLine($"Total de registros: {employeeService.Count}");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("| Rol                | Servicio              |");
            Console.WriteLine("-----------------------------------------------");

            foreach (var item in employeeService)
            {
                Console.WriteLine($"| {item.RoleDescription,-18} | {item.ServiceDescription,-20} |");
            }
            Console.WriteLine("-----------------------------------------------");

        }

        [TearDown] //borra todo al terminar el test
        public void afterTest()
        {
            _dbContext.Dispose();
        }
    }
}