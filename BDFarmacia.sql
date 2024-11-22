
Create database BaseFarmacia;
Use BaseFarmacia

CREATE TABLE Persona(
 Id_Persona INT IDENTITY(1,1) PRIMARY KEY,
 PrimerNombre VARCHAR(50) NOT NULL,
 SegundoNombre VARCHAR(50),
 PrimerApellido VARCHAR(50) NOT NULL,
 SegundoApellido VARCHAR(50),
 Direccion VARCHAR(200) NOT NULL,
 Correo VARCHAR(100),
 Sexo CHAR(1) NOT NULL,
 )

CREATE TABLE Empleado (
    IdEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Cargo VARCHAR(50) NOT NULL,
    CodigoUsuario VARCHAR(50) NOT NULL,
    Edad INT NOT NULL,
    EstadoEmpleado BIT NOT NULL,
    NivelAcceso INT NOT NULL,
    LoginUsuario VARCHAR(50) NOT NULL,
    PasswordUsuario VARCHAR(100) NOT NULL,
    Telefono CHAR(8),
	Id_Persona INT,
	CONSTRAINT CK_Empleado_Telefono check (Telefono like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
);

CREATE TABLE Usuario (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Estado BIT NOT NULL,
    Rol CHAR(1) NOT NULL,
	IdEmpleado INT NOT NULL
);

CREATE TABLE Categoria (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    NombreCategoria VARCHAR(50) NOT NULL
);


CREATE TABLE Proveedor (
    IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
    Estado BIT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    FechaUltimoPedido DATETIME NOT NULL,
    NombreCompania NVARCHAR(100) NOT NULL,
    Id_Persona INT NOT NULL,
    Telefono CHAR(8),
	CONSTRAINT CK_Proveedor_Telefono check (Telefono like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
);

CREATE TABLE ProveedorTrabajador(
	IdTrabajador int primary key identity(1,1),
	PrimerNombre varchar(50),
	SegundoNombre varchar(50),
	PrimerApellido varchar(50),
	SegundoApellido varchar(50),
	DireccionTrabajador varchar(50),
	Cargo varchar(50),
	Edad int,
	TelefonoTrabajador char(8),
	Sexo varchar(10),
	CHECK (TelefonoTrabajador LIKE '[5|7|8][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	IdProveedor INT NOT NULL
)
GO


CREATE TABLE Producto (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,
    Concentracion VARCHAR(50) NOT NULL,
	UnidadMedida char(2),
    DescripcionProducto VARCHAR(200) NOT NULL,
    EstadoProducto BIT NOT NULL,
    FechaFabricacion DATETIME NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    FechaVencimiento DATETIME NOT NULL,
    IdCategoria INT NOT NULL,
    IdProveedor INT NOT NULL,
	IdPresentacion INT NOT NULL,
	IdRubro INT NOT NULL,
	IdTipoProducto INT NOT NULL,
    MargenGanancias DECIMAL(10,2) NOT NULL,
    NombreProducto NVARCHAR(100) NOT NULL,
    PrecioCompra DECIMAL(10,2) NOT NULL,
    PrecioVenta DECIMAL(10,2) NOT NULL,
    StockMinimo INT NOT NULL,
    StockMaximo INT NOT NULL,
    StockMedio INT NOT NULL
);


CREATE TABLE ClienteNatural (
    IdCliente INT PRIMARY KEY,
    Edad INT NOT NULL,
    Estado BIT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    Id_Persona INT NOT NULL,
    Telefono CHAR(8),
	CONSTRAINT CK_ClienteNatural_Telefono check (Telefono like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
);

CREATE TABLE Compra (
    IdCompra INT IDENTITY(1,1) PRIMARY KEY,
    Monto DECIMAL(10,2) NOT NULL,
    Fecha DATETIME NOT NULL,
	IdProveedor INT NOT NULL
);
Alter table Compra add NFactura Int not null


CREATE TABLE Venta(
    IdVenta INT IDENTITY(1,1) PRIMARY KEY,
	Monto DECIMAL(10,2) NOT NULL,
	NRecibo INT NOT NULL,
	Fecha DATETIME NOT NULL,
	IdCliente INT NOT NULL
);


CREATE TABLE Recibo (
    NRecibo INT IDENTITY(1,1) PRIMARY KEY,
    CostoProducto DECIMAL(10,2) NOT NULL,
	IdTransaccion INT NOT NULL
);


CREATE TABLE Transaccion (
    IdTransaccion INT IDENTITY(1,1) PRIMARY KEY,
    Descuento DECIMAL (10,2),
    Estado CHAR(1) NOT NULL,
    Fecha DATETIME NOT NULL,
    Iva DECIMAL (10,2) NOT NULL,
    SubTotal DECIMAL (10,2) NOT NULL,
    Tipo CHAR(1) NOT NULL,
    Total DECIMAL(10,2) NOT NULL

);

CREATE TABLE Presentacion(
	IdPresentacion int primary key identity(1,1),
	Nombre varchar(40),
	EstadoPresentacion bit default 1
)
GO

CREATE TABLE Rubro(
	IdRubro int primary key identity(1,1),
	Nombre varchar(40),
	Estado bit default 1
)
GO


CREATE TABLE TipoProducto(
	IdTipoProducto int primary key identity(1,1),
	Descripcion varchar(11),
	Estado bit default 1,
	CHECK (Descripcion IN ('GENERICO','NO GENERICO'))
)

CREATE TABLE DevolucionVenta (
    IdDevolucionVenta INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    MotivoDevolucion VARCHAR(200) NOT NULL,
    NDevolucion INT NOT NULL,
    NRecibo INT NOT NULL
);


CREATE TABLE DevolucionCompra (
    IdDevolucionCompra INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    MotivoDevolucion VARCHAR(200) NOT NULL,
    NDevolucion INT NOT NULL,
    IdCompra INT NOT NULL
);

CREATE TABLE DetalleCompra(
    IdDetalleCompra INT IDENTITY(1,1) PRIMARY KEY,
	Cantidad INT NOT NULL,
	Precio DECIMAL(10,2) NOT NULL,
	SubTotal DECIMAL(10,2) NOT  NULL,
	IdCompra INT NOT NULL
	);

 insert into Empleado values ('Programador','9423',21,1,1,'rmaradiaga','facil123','58627263',1)
 insert into Usuario values (1,'1',1)





