create database prueba283;

use prueba283;

create table Roles (
	Id int primary key identity(1,1),
	Nombre varchar(20) not null,
);
insert into Roles(Nombre) values('admin');
insert into Roles(Nombre) values('usuario');
insert into Roles(Nombre) values('contador');

create table Usuarios (
	Id int primary key identity(1,1),
	Username varchar(20) not null,
	PasswordHash varchar(255) not null,
	RolId int not null,

	constraint usuarios_roles_fk foreign key(RolId) references Roles (Id),
);

create table Cuentas (
	Id int primary key identity(1,1),
	NumeroCuenta int not null,
	Division varchar(20) not null,
	Moneda varchar(3) not null,
	Saldo decimal(10,2) not null,
	FechaCreacion date not null,
	Estado varchar(1) not null,

	constraint ch_estadorc check (Estado in ('A', 'I', 'N')),
	constraint ch_division check (Division in ('AHORROS', 'INVERSIONES', 'GASTOS')),
	constraint ch_moneda check (Moneda in ('USD', 'EUR', 'GBP')),
);

create table TasasCambio (
	Id int primary key identity(1,1),
	MonedaOrigen varchar(3) not null,
	MonedaDestino varchar(3) not null,
	TasaCambio int not null,
	FechaActualizacion date not null,
	Estado varchar(1) not null,

	constraint ch_estadotc check (Estado in ('A', 'I', 'N')),
	constraint ch_origen check (MonedaOrigen in ('USD', 'EUR', 'GBP')),
	constraint ch_destino check (MonedaDestino in ('USD', 'EUR', 'GBP')),
);
insert into TasasCambio(MonedaOrigen,MonedaDestino,TasaCambio,FechaActualizacion,Estado) 
	values('EUR', 'USD', 2, '2025-03-28', 'A');
insert into TasasCambio(MonedaOrigen,MonedaDestino,TasaCambio,FechaActualizacion,Estado) 
	values('GBP', 'USD', 4, '2025-03-28', 'A');
insert into TasasCambio(MonedaOrigen,MonedaDestino,TasaCambio,FechaActualizacion,Estado) 
	values('EUR', 'GBP', 3, '2025-03-28', 'A');
insert into TasasCambio(MonedaOrigen,MonedaDestino,TasaCambio,FechaActualizacion,Estado) 
	values('USD', 'EUR', 2, '2025-03-28', 'A');
insert into TasasCambio(MonedaOrigen,MonedaDestino,TasaCambio,FechaActualizacion,Estado) 
	values('USD', 'GBP', 5, '2025-03-28', 'A');

create table ReglasDistribucion (
	Id int primary key identity(1,1),
	Division varchar(5) not null,
	Porcentaje decimal(10,2) not null,
	Estado varchar(1) not null,

	constraint ch_estadord check (Estado in ('A', 'I', 'N')),
);

select * from roles;
select * from usuarios;