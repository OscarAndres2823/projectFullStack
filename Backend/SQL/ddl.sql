-- Tabla: roles_usuarios
CREATE TABLE roles_usuarios (
    rol_id SERIAL PRIMARY KEY,
    nombre VARCHAR(30)
);

-- Tabla: usuarios
CREATE TABLE usuarios (
    usuario_id SERIAL PRIMARY KEY,
    rol_id INTEGER REFERENCES roles_usuarios(rol_id),
    correo TEXT UNIQUE NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    password TEXT NOT NULL,
    documento VARCHAR(15) UNIQUE NOT NULL,
    telefono VARCHAR(50) NOT NULL
);

-- Tabla: clientes
CREATE TABLE clientes (
    cliente_id SERIAL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    telefono VARCHAR(20) NOT NULL,
    documento VARCHAR(15) UNIQUE NOT NULL,
    correo VARCHAR(50) NOT NULL
);

-- Tabla: vehiculos
CREATE TABLE vehiculos (
    vehiculo_id SERIAL PRIMARY KEY,
    cliente_id INTEGER REFERENCES clientes(cliente_id),
    marca VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    year DATE NOT NULL,
    vin VARCHAR(30) UNIQUE NOT NULL,
    kilometraje DECIMAL(10,2)
);

-- Tabla: tipos_servicios
CREATE TABLE tipos_servicios (
    tipo_servicio_id SERIAL PRIMARY KEY,
    nombre VARCHAR(50)
);

-- Tabla: ordenes_servicios
CREATE TABLE ordenes_servicios (
    orden_id SERIAL PRIMARY KEY,
    vehiculo_id INTEGER REFERENCES vehiculos(vehiculo_id) NOT NULL,
    tipo_servicio_id INTEGER REFERENCES tipos_servicios(tipo_servicio_id) NOT NULL,
    usuario_id INTEGER REFERENCES usuarios(usuario_id),
    fecha_ingreso TIMESTAMP NOT NULL,
    fecha_estimada TIMESTAMP
);

-- Tabla: repuestos
CREATE TABLE repuestos (
    repuesto_id SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    codigo VARCHAR(50) NOT NULL UNIQUE,
    descripcion TEXT,
    stock INTEGER NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL
);

-- Tabla: detalles_ordenes
CREATE TABLE detalles_ordenes (
    detalleorden_id SERIAL PRIMARY KEY,
    orden_id INTEGER REFERENCES ordenes_servicios(orden_id) NOT NULL,
    repuesto_id INTEGER REFERENCES repuestos(repuesto_id) NOT NULL,
    cantidad INTEGER NOT NULL,
    precio_total DECIMAL(10,2) NOT NULL
);

-- Tabla: facturas
CREATE TABLE facturas (
    factura_id VARCHAR(20) PRIMARY KEY,
    orden_id INTEGER REFERENCES ordenes_servicios(orden_id),
    monto_total DECIMAL(10,2) NOT NULL,
    mano_obra DECIMAL(10,2) NOT NULL,
    valor_total DECIMAL(10,2) NOT NULL
);

CREATE TABLE auditorias (
    auditoria_id SERIAL PRIMARY KEY,
    entidad VARCHAR(50) NOT NULL,
    accion VARCHAR(20) NOT NULL,
    usuario_id INTEGER REFERENCES usuarios(usuario_id) NOT NULL,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);