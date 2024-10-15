USE [PapeleriaObligatorio]
GO
--Admins
INSERT INTO Usuarios(Nombre, Apellido, Email, Discriminator, Password_Encriptada, Password_Valor) VALUES 

('Santiago', 'Correge', 'corregesantiago@gmail.com', 'Administrador', 'f4035833cb911a3e8634903e498ff84b05d4b66f73c6155af3f58b22ad3503f4' , 'Admin123.' ),
('AdmDos', 'ApeAdmDos', 'admdos@gmail.com', 'Administrador', 'b4d36e8e34ad2575bfdba231f4091a39bf78c0eac815466ab5012df209dedc31', 'Admin234.')


--Miembros
INSERT INTO Usuarios(Nombre, Apellido, Email, Discriminator, Password_Encriptada, Password_Valor) VALUES 
('MroUno', 'ApeMroUno', 'mrouno@gmail.com', 'Miembro', 'f4035833cb911a3e8634903e498ff84b05d4b66f73c6155af3f58b22ad3503f4', 'Admin123.'),
('MroDos', 'ApeMroDos', 'mrodos@gmail.com', 'Miembro', 'b4d36e8e34ad2575bfdba231f4091a39bf78c0eac815466ab5012df209dedc31', 'Admin234.')


--Clientes

INSERT INTO Clientes(RazonSocial, RUT, Direccion_Calle, Direccion_Ciudad, Direccion_Distancia, Direccion_Numero) VALUES
('Samsung', 100000000001, '21 Septiembre', 'Montevideo', 200.00, 2043),
('Antel', 100000000002, 'Luis Alberto de Herrera', 'Montevideo', 170.00, 623),
('TiendaMia', 100000000003, 'Camino 23', 'Canelones', 200.00, 531),
('Reebok', 100000000004, 'Camino 24', 'Canelones', 150.00, 523),
('Pepsi', 100000000005, 'Camino 24', 'Montevideo', 200.00, 1022),
('Coca-Cola', 100000000006, 'Camino 25', 'Montevideo', 20.00, 3255),
('IPhone', 100000000007, 'Camino 26', 'Montevideo', 5.00, 4093),
('PepGua', 100000000008, 'Camino 27', 'Montevideo', 300.00, 3011),
('Juanas', 100000000009, 'Camino 28', 'Montevideo', 150.00, 1062),
('Nike', 100000000010, 'Camino 29', 'Montevideo', 1000.00, 5043)


--Articulos
INSERT INTO Articulos(Nombre, Descripcion, Codigo, PrecioActual, Stock) VALUES

('Pack Hojas A4', 'Pack 200 Hojas A4','A000000000001', 50.00, 100),
('Lapicera Bic Azul', 'Lapicera Bic Azul','A000000000002', 13.00, 30),
('Lapicera Bic Roja', 'Lapicera Bic Roja','A000000000003', 13.00, 50),
('Corrector Mapx', 'Corrector 50 ml','A000000000004', 35.00, 15),
('Lapiz Grafo seth', 'Seth Lujo 21','A000000000005', 125.00, 3),
('Carpeta Lont', 'Carpeta plastico estandar','A000000000006', 18.00, 40),
('Cartuchera chikilin', 'Cartuchera 20X5 tela','A000000000007', 50.00, 10),
('Juego Geometria Lont', 'Regla, Escuadra, Compaz, ','A000000000008', 50.00, 12),
('Impresora 3D GeoM', 'GeoM-A32','A000000000009', 50.00, 2),
('Escaner Temsr', 'Temsr-012','A0000000000010', 50.00, 10)

--Parametros
INSERT INTO Parametros(Nombre, Valor) VALUES
('Iva', '0.22'),
('PlazoPedidoComun', '7'),
('PlazoPedidoExpress', '5'),
('ExpresRecargoBase', '10'),
('ExpresRecargoMismoDia', '15'),
('ComunRecargoDistancia', '5')





