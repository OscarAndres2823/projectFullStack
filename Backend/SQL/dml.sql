-- Roles
INSERT INTO roles_usuarios (nombre) VALUES 
  ('Admin'), 
  ('Mecánico'), 
  ('Recepcionista');

-- Usuarios
INSERT INTO usuarios (rol_id, correo, password, nombre, documento, telefono) VALUES
  (1, 'admin@taller.com', 'hashedpassword1', 'Administrador Uno', '100000001', '3001234567'),
  (2, 'mecanico@taller.com', 'hashedpassword2', 'Mecánico Dos', '100000002', '3001234568'),
  (3, 'recep@taller.com', 'hashedpassword3', 'Recepcionista Tres', '100000003', '3001234569');

-- Clientes
INSERT INTO clientes (nombre, telefono, documento, correo) VALUES
  ('Carlos Pérez', '3101112233', '900000001', 'carlos@example.com'),
  ('Laura Gómez', '3102223344', '900000002', 'laura@example.com');

-- Vehículos
INSERT INTO vehiculos (cliente_id, marca, modelo, year, vin, kilometraje) VALUES
  (1, 'Toyota', 'Corolla', '2018-01-01', 'JT1234567890ABC01', 75000.5),
  (2, 'Mazda', '3', '2020-06-15', 'JM1234567890DEF02', 40500.0);

-- Tipos de Servicios
INSERT INTO tipos_servicios (nombre) VALUES
  ('Mantenimiento preventivo'),
  ('Reparación'),
  ('Diagnóstico');

-- Órdenes de Servicio
INSERT INTO ordenes_servicios (vehiculo_id, tipo_servicio_id, usuario_id, fecha_ingreso, fecha_estimada) VALUES
  (1, 1, 2, '2025-06-17 19:44:13', '2025-06-20 19:44:13'),
  (2, 2, 2, '2025-06-17 19:44:13', '2025-06-22 19:44:13');

-- Repuestos
INSERT INTO repuestos (codigo, descripcion, stock, precio_unitario) VALUES
  ('R001', 'Filtro de aceite', 10, 30.50),
  ('R002', 'Pastillas de freno', 15, 45.75);

-- Detalles de Órdenes
INSERT INTO detalles_ordenes (orden_id, repuesto_id, cantidad, precio_total) VALUES
  (1, 1, 2, 61.00),
  (2, 2, 1, 45.75);

-- Facturas
INSERT INTO facturas (factura_id, order_id, monto_total, mano_obra, valor_total) VALUES
  ('FAC001', 1, 61.00, 6.10, 67.10),
  ('FAC002', 2, 45.75, 4.58, 50.33);

-- Auditorías
INSERT INTO auditorias (entidad, accion, usuario_id) VALUES
  ('ordenes_servicios', 'CREATE', 2),
  ('facturas', 'CREATE', 2);
