CREATE TABLE Rol (
    id_rol INT IDENTITY(1,1) PRIMARY KEY,
    descripcion NVARCHAR(50)
);

CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100),
    email NVARCHAR(100),
    contraseña NVARCHAR(100),
    id_rol INT,
    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
);

CREATE TABLE Categoria (
    Id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100),
    descripcion NVARCHAR(255),
    imagen NVARCHAR(255),
    created_at DATETIME,
    updated_at DATETIME,
    deleted_at DATETIME
);

CREATE TABLE Cliente (
    Id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100),
    apellido NVARCHAR(100),
    dni INT,
    fecha_nacimiento DATETIME,
    fecha_registro DATETIME,
    domicilio NVARCHAR(255),
    correo NVARCHAR(100)
);

CREATE TABLE Producto (
    Id_producto INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100),
    descripcion NVARCHAR(255),
    precio DECIMAL(10,2),
    stock INT,
    id_categoria INT,
    created_at DATETIME,
    updated_at DATETIME,
    deleted_at DATETIME,
    CONSTRAINT FK_Producto_Categoria FOREIGN KEY (id_categoria) REFERENCES Categoria(Id_categoria)
);

CREATE TABLE VentaCabecera (
    Id_ventaCabecera INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT,
    id_usuario INT,
    tipo_factura NVARCHAR(50),
    nro_factura NVARCHAR(50),
    total DECIMAL(10,2),
    fecha_venta DATETIME,
    CONSTRAINT FK_Venta_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(Id_cliente),
    CONSTRAINT FK_Venta_Usuario FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

CREATE TABLE VentaDetalle (
    Id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_ventaCabecera INT,
    id_producto INT,
    cantidad INT,
    precio_unitario DECIMAL(10,2),
    subtotal DECIMAL(10,2),
    CONSTRAINT FK_Detalle_Venta FOREIGN KEY (id_ventaCabecera) REFERENCES VentaCabecera(Id_ventaCabecera),
    CONSTRAINT FK_Detalle_Producto FOREIGN KEY (id_producto) REFERENCES Producto(Id_producto)
);