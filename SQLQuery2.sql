-- Insertar los roles básicos si aún no existen
SET IDENTITY_INSERT Rol ON; -- Solo necesario si la columna id_rol es IDENTITY

INSERT INTO Rol (id_rol, descripcion) VALUES (1, 'Administrador');
INSERT INTO Rol (id_rol, descripcion) VALUES (2, 'Vendedor');

SET IDENTITY_INSERT Rol OFF;