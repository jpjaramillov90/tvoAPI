using Microsoft.EntityFrameworkCore;
using tvo.Aplicacion.Service;
using tvo.Aplicacion.ServiceImpl;
using tvo.Infraestructura.AccesoDatos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conectionDB = builder.Configuration.GetConnectionString("ConexionDBTVO");

//2.- Crear el dbContext con la conexión almacenada
builder.Services.AddDbContext<db_tvoContext>(options => options.UseSqlServer(conectionDB), ServiceLifetime.Scoped);

//3. Configurar los servicios
builder.Services.AddScoped<IBrandsService, BrandsServiceImpl>();
builder.Services.AddScoped<IBudgetService, BudgetServiceImpl>();
builder.Services.AddScoped<IBudgetStatementService, BudgetStatementServiceImpl>();
builder.Services.AddScoped<IClientService, ClientServiceImpl>();
builder.Services.AddScoped<IClientStatusService, ClientStatusServiceImpl>();
builder.Services.AddScoped<ICooperativeService, CooperativeServiceImpl>();
builder.Services.AddScoped<IEmployeeService, EmployeeServiceImpl>();
builder.Services.AddScoped<IModelsService, ModelsServiceImpl>();
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsServiceImpl>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusServiceImpl>();
builder.Services.AddScoped<IRolEmployeeService, RolEmployeeServiceImpl>();
builder.Services.AddScoped<IServicePriceHistoryService, ServicePriceHistoryServiceImpl>();
builder.Services.AddScoped<IServicePriceService, ServicePriceServiceImpl>();
builder.Services.AddScoped<IServicesService, ServicesServiceImpl>();
builder.Services.AddScoped<ISpecialtiesService, SpecialtiesServiceImpl>();
builder.Services.AddScoped<ITransportDataService, TransportDataServiceImpl>();
builder.Services.AddScoped<ITransportService, TransportServiceImpl>();
builder.Services.AddScoped<IWorkOrderService, WorkOrderServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
