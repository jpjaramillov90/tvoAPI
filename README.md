create database db_tvo;
go

use db_tvo;
go

create table clientStatus(
	idClientStatus int identity(1,1) CONSTRAINT PK_ClientStatus PRIMARY KEY CLUSTERED,
	clientStatus varchar(10) not null
);
go

create table client(
	idClient INT identity(1,1) CONSTRAINT PK_Client PRIMARY KEY CLUSTERED,
	nui varchar(15) not null CONSTRAINT UQ_Client_NUI UNIQUE,
	firstName varchar(25) not null,
	lastName varchar(25) not null,
	phone varchar(20) not null,
	mail varchar(45) not null,
	addressClient varchar(100) not null,
	passwordClient varchar(15) not null,
	idClientStatus int constraint FK_Client_ClientStatus_idClientStatus foreign key (idClientStatus) references clientStatus(idClientStatus) ON UPDATE CASCADE
);
go

create table transport (
	idTransport int identity(1,1) constraint PK_Transport primary key clustered,
	typeTransport varchar(25) not null
);
go

create table cooperative(
	idCooperative int identity (1,1) constraint PK_Cooperative primary key clustered,
	nameCooperative varchar(45) not null
);
go

create table transportData (
	idTransportData int identity(1,1) constraint PK_TransportData primary key clustered,
	idTransport int constraint FK_TransportData_Transport_idTransport foreign key (idTransport) references transport(idTransport) on update cascade on delete cascade,
	idCooperative int constraint FK_TransportData_Cooperative_idCooperative foreign key (idCooperative) references cooperative(idCooperative) on update cascade on delete cascade,
	idClient int constraint FK_TransportData_Client_idClient foreign key (idClient) references client(idClient) on update cascade on delete cascade,
	plate varchar(10) not null,
	num int not null,
	chassis varchar(45) not null
);
go

create table brands(
	idBrands int identity(1,1) constraint PK_Brands primary key clustered,
	brand varchar(45) not null
);
go

create table models(
	idModels int identity(1,1) constraint PK_Models primary key clustered,
	idBrands int constraint FK_Models_Brands_idBrands foreign key (idBrands) references brands(idBrands) on update cascade on delete cascade,
	models varchar(45) not null
);
go

create table rolEmployee(
	idRolEmployee int identity(1,1) constraint PK_RolEmployee primary key clustered,
	descriptionRol varchar(15) not null
);
go

create table specialties (
	idSpecialties int identity(1,1) constraint PK_Specialties primary key clustered,
	specialty varchar(25) not null
);
go

create table employee(
	idEmployee int identity(1,1) constraint PK_Employee primary key clustered,
	idSpecialties int constraint FK_Employee_Specialties_idSpecialties foreign key (idSpecialties) references specialties(idSpecialties) on update cascade on delete cascade,
	idRolEmployee int constraint FK_Employee_RolEmployee_idRolEmployee foreign key (idRolEmployee) references rolEmployee(idRolEmployee) on update cascade on delete cascade,
	nui varchar(13) not null,
	firstName varchar(45) not null,
	lastName varchar(45) not null,
	phone varchar(25) not null,
	addressEmp varchar(100) not null,
	mail varchar(45) not null
);
go

create table services (
	idService int identity(1,1) constraint PK_Services primary key clustered,
	descriptionServices varchar(45) not null
);
go

create table servicePrice(
	idServicePrice int identity(1,1) constraint PK_ServicePrice primary key clustered,
	idService int constraint FK_ServicePrice_Services_idService foreign key (idService) references services(idService),
	price decimal(10,2)
);
go

create table servicePriceHistory(
	idServicePriceHistory int identity(1,1) constraint PK_ServicePriceHistory primary key clustered,
	idServicePrice int constraint FK_ServicePriceHistory_ServicePrice_idServicePrice foreign key (idServicePrice) references servicePrice(idServicePrice) on update cascade on delete cascade,
	price decimal(10,2),
	startDate date constraint DF_servicePriceHistory_startDate default getdate(),
	endDate date default NULL,
	changeBy varchar(25) not null
);
go

create table orderStatus(
	idOrderStatus int identity(1,1) constraint PK_OrderStatus primary key clustered,
	orderStatus varchar(20)
);
go

create table workOrder(
	idWorkOrder int identity(1,1) constraint PK_WorkOrder primary key clustered,
	idEmployee int constraint FK_WorkOrder_Employee_idEmployee foreign key (idEmployee) references employee(idEmployee) on update cascade on delete cascade,
	idOrderStatus int constraint FK_WorkOrder_OrderStatus_idOrderStatus foreign key (idOrderStatus) references orderStatus(idOrderStatus) on update cascade on delete cascade,
	descriptionWO varchar(45),
	expires date not null
);
go

create table orderDetails(
	idOrderDetails int identity(1,1) constraint PK_OrderDetails primary key clustered,
	idWorkOrder int constraint FK_OrderDetails_WorkOrder_idWorkOrder foreign key (idWorkOrder) references workOrder(idWorkOrder) on update cascade on delete cascade,
	idService int constraint FK_OrderDetails_Services_idService foreign key (idService) references services(idService) on update cascade on delete cascade
);
go

create table budgetStatement(
	idBudgetStatement int identity(1,1) constraint PK_BudgetStatement primary key clustered,
	descriptionStatement varchar(45) not null
);
go

create table budget(
	idBudget int identity(1,1) constraint PK_Budget primary key clustered,
	idWorkOrder int constraint FK_Budget_WorkOrder_idWorkOrder foreign key (idWorkOrder) references workOrder(idWorkOrder) on update cascade on delete cascade,
	idTransportData int constraint FK_Budget_TransportData_idTransportData foreign key (idTransportData) references transportData(idTransportData) on update cascade on delete cascade,
	idBudgetStatement int constraint FK_Budget_BudgetStatement_idBudgetStatement foreign key (idBudgetStatement) references budgetStatement(idBudgetStatement) on update cascade on delete cascade,
	idBrands int constraint FK_Budget_Brands_idBrands foreign key (idBrands) references brands(idBrands) on update cascade on delete cascade,
	issueDate date constraint DF_budget_issueDate default getdate(),
	validUntil DATE constraint DF_budget_validUntil DEFAULT DATEADD(day, 15, GETDATE()),
	comments varchar(45)
);
go

CREATE TRIGGER trg_ins_servicePriceHistory
on servicePrice
after update
as
	begin
		SET NOCOUNT ON;

		UPDATE sph
		SET sph.endDate = GETDATE()
		FROM servicePriceHistory sph
		INNER JOIN inserted i ON sph.idServicePrice = i.idServicePrice
		INNER JOIN deleted d ON i.idServicePrice = d.idServicePrice
		WHERE i.price <> d.price
		AND sph.endDate IS NULL;

		INSERT INTO servicePriceHistory (idServicePrice, startDate,	changeBy)
		SELECT i.idServicePrice, GETDATE(), SYSTEM_USER
		FROM inserted i
		INNER JOIN deleted d ON i.idServicePrice = d.idServicePrice
		WHERE i.price <> d.price;
	end;
go
