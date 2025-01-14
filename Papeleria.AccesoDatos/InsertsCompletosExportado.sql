USE [PapeleriaObligatorio]
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 

INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (1, N'Pack Hojas A4', N'Pack 200 Hojas A4', N'A000000000001', CAST(50.00 AS Decimal(10, 2)), 100)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (2, N'Lapicera Bic Azul', N'Lapicera Bic Azul', N'A000000000002', CAST(13.00 AS Decimal(10, 2)), 30)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (3, N'Lapicera Bic Roja', N'Lapicera Bic Roja', N'A000000000003', CAST(13.00 AS Decimal(10, 2)), 50)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (4, N'Corrector Mapx', N'Corrector 50 ml', N'A000000000004', CAST(35.00 AS Decimal(10, 2)), 15)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (5, N'Lapiz Grafo seth', N'Seth Lujo 21', N'A000000000005', CAST(125.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (6, N'Carpeta Lont', N'Carpeta plastico estandar', N'A000000000006', CAST(18.00 AS Decimal(10, 2)), 40)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (7, N'Cartuchera chikilin', N'Cartuchera 20X5 tela', N'A000000000007', CAST(50.00 AS Decimal(10, 2)), 10)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (8, N'Juego Geometria Lont', N'Regla, Escuadra, Compaz, ', N'A000000000008', CAST(50.00 AS Decimal(10, 2)), 12)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (9, N'Impresora 3D GeoM', N'GeoM-A32', N'A000000000009', CAST(50.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Articulos] ([Id], [Nombre], [Descripcion], [Codigo], [PrecioActual], [Stock]) VALUES (10, N'Escaner Temsr', N'Temsr-012', N'A0000000000010', CAST(50.00 AS Decimal(10, 2)), 10)
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (1, N'Samsung', 100000000001, N'21 Septiembre', N'Montevideo', CAST(200.00 AS Decimal(18, 2)), 2043)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (2, N'Antel', 100000000002, N'Luis Alberto de Herrera', N'Montevideo', CAST(170.00 AS Decimal(18, 2)), 623)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (3, N'TiendaMia', 100000000003, N'Camino 23', N'Canelones', CAST(200.00 AS Decimal(18, 2)), 531)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (4, N'Reebok', 100000000004, N'Camino 24', N'Canelones', CAST(150.00 AS Decimal(18, 2)), 523)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (5, N'Pepsi', 100000000005, N'Camino 24', N'Montevideo', CAST(200.00 AS Decimal(18, 2)), 1022)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (6, N'Coca-Cola', 100000000006, N'Camino 25', N'Montevideo', CAST(20.00 AS Decimal(18, 2)), 3255)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (7, N'IPhone', 100000000007, N'Camino 26', N'Montevideo', CAST(5.00 AS Decimal(18, 2)), 4093)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (8, N'PepGua', 100000000008, N'Camino 27', N'Montevideo', CAST(300.00 AS Decimal(18, 2)), 3011)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (9, N'Juanas', 100000000009, N'Camino 28', N'Montevideo', CAST(150.00 AS Decimal(18, 2)), 1062)
INSERT [dbo].[Clientes] ([Id], [RazonSocial], [RUT], [Direccion_Calle], [Direccion_Ciudad], [Direccion_Distancia], [Direccion_Numero]) VALUES (10, N'Nike', 100000000010, N'Camino 29', N'Montevideo', CAST(1000.00 AS Decimal(18, 2)), 5043)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedidos] ON 

INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (1, CAST(N'2024-05-14' AS Date), CAST(N'2024-05-22' AS Date), 1, CAST(5.00 AS Decimal(10, 2)), CAST(23.06 AS Decimal(10, 2)), 1, N'PedidoComun')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (2, CAST(N'2024-05-14' AS Date), CAST(N'2024-05-22' AS Date), 6, CAST(0.00 AS Decimal(10, 2)), CAST(418.46 AS Decimal(10, 2)), 1, N'PedidoComun')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (3, CAST(N'2024-05-14' AS Date), CAST(N'2024-05-14' AS Date), 5, CAST(15.00 AS Decimal(10, 2)), CAST(325.50 AS Decimal(10, 2)), 1, N'PedidoExpress')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (4, CAST(N'2024-05-14' AS Date), CAST(N'2024-05-16' AS Date), 9, CAST(10.00 AS Decimal(10, 2)), CAST(174.46 AS Decimal(10, 2)), 1, N'PedidoExpress')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (5, CAST(N'2024-05-14' AS Date), CAST(N'2024-05-14' AS Date), 8, CAST(15.00 AS Decimal(10, 2)), CAST(561.20 AS Decimal(10, 2)), 1, N'PedidoExpress')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (6, CAST(N'2024-05-14' AS Date), CAST(N'2024-05-17' AS Date), 10, CAST(10.00 AS Decimal(10, 2)), CAST(382.47 AS Decimal(10, 2)), 1, N'PedidoExpress')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (7, CAST(N'2024-05-14' AS Date), CAST(N'2024-05-24' AS Date), 10, CAST(5.00 AS Decimal(10, 2)), CAST(345.87 AS Decimal(10, 2)), 1, N'PedidoComun')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (8, CAST(N'2024-05-14' AS Date), CAST(N'2024-06-07' AS Date), 7, CAST(0.00 AS Decimal(10, 2)), CAST(201.30 AS Decimal(10, 2)), 1, N'PedidoComun')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (9, CAST(N'2024-05-14' AS Date), CAST(N'2024-06-04' AS Date), 5, CAST(5.00 AS Decimal(10, 2)), CAST(46.12 AS Decimal(10, 2)), 1, N'PedidoComun')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (10, CAST(N'2024-05-14' AS Date), CAST(N'2024-12-11' AS Date), 8, CAST(5.00 AS Decimal(10, 2)), CAST(23.06 AS Decimal(10, 2)), 1, N'PedidoComun')
INSERT [dbo].[Pedidos] ([Id], [FechaPedido], [FechaEntrega], [ClienteId], [Recargo], [CostoPedido], [Valido], [Discriminator]) VALUES (11, CAST(N'2024-05-14' AS Date), CAST(N'2024-05-14' AS Date), 6, CAST(15.00 AS Decimal(10, 2)), CAST(91.20 AS Decimal(10, 2)), 1, N'PedidoExpress')
SET IDENTITY_INSERT [dbo].[Pedidos] OFF
GO
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (1, 6, CAST(18.00 AS Decimal(10, 2)), 1, CAST(18.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (2, 3, CAST(13.00 AS Decimal(10, 2)), 3, CAST(39.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (2, 6, CAST(18.00 AS Decimal(10, 2)), 3, CAST(54.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (2, 10, CAST(50.00 AS Decimal(10, 2)), 5, CAST(250.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (3, 3, CAST(13.00 AS Decimal(10, 2)), 6, CAST(78.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (3, 6, CAST(18.00 AS Decimal(10, 2)), 3, CAST(54.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (3, 7, CAST(50.00 AS Decimal(10, 2)), 2, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (4, 2, CAST(13.00 AS Decimal(10, 2)), 4, CAST(52.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (4, 3, CAST(13.00 AS Decimal(10, 2)), 6, CAST(78.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (5, 1, CAST(50.00 AS Decimal(10, 2)), 8, CAST(400.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (6, 2, CAST(13.00 AS Decimal(10, 2)), 5, CAST(65.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (6, 4, CAST(35.00 AS Decimal(10, 2)), 2, CAST(70.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (6, 7, CAST(50.00 AS Decimal(10, 2)), 3, CAST(150.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (7, 3, CAST(13.00 AS Decimal(10, 2)), 5, CAST(65.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (7, 4, CAST(35.00 AS Decimal(10, 2)), 3, CAST(105.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (7, 9, CAST(50.00 AS Decimal(10, 2)), 2, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (8, 2, CAST(13.00 AS Decimal(10, 2)), 5, CAST(65.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (8, 8, CAST(50.00 AS Decimal(10, 2)), 2, CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (9, 6, CAST(18.00 AS Decimal(10, 2)), 2, CAST(36.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (10, 6, CAST(18.00 AS Decimal(10, 2)), 1, CAST(18.00 AS Decimal(10, 2)))
INSERT [dbo].[Linea] ([PedidoId], [ArticuloId], [PrecioVigente], [Cantidad], [Costo]) VALUES (11, 2, CAST(13.00 AS Decimal(10, 2)), 5, CAST(65.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240514170433_Nueva-Reset', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240515022025_NuevaMigracion-RecetMigraciones', N'8.0.4')
GO
INSERT [dbo].[Parametros] ([Nombre], [Valor]) VALUES (N'ComunRecargoDistancia', N'5')
INSERT [dbo].[Parametros] ([Nombre], [Valor]) VALUES (N'ExpresRecargoBase', N'10')
INSERT [dbo].[Parametros] ([Nombre], [Valor]) VALUES (N'ExpresRecargoMismoDia', N'15')
INSERT [dbo].[Parametros] ([Nombre], [Valor]) VALUES (N'Iva', N'0.22')
INSERT [dbo].[Parametros] ([Nombre], [Valor]) VALUES (N'PlazoPedidoComun', N'7')
INSERT [dbo].[Parametros] ([Nombre], [Valor]) VALUES (N'PlazoPedidoExpress', N'5')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Email], [Discriminator], [Password_Encriptada], [Password_Valor]) VALUES (1, N'Santiago', N'Correge', N'corregesantiago@gmail.com', N'Administrador', N'f4035833cb911a3e8634903e498ff84b05d4b66f73c6155af3f58b22ad3503f4', N'Admin123.')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Email], [Discriminator], [Password_Encriptada], [Password_Valor]) VALUES (2, N'AdmDos', N'ApeAdmDos', N'admdos@gmail.com', N'Administrador', N'b4d36e8e34ad2575bfdba231f4091a39bf78c0eac815466ab5012df209dedc31', N'Admin234.')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Email], [Discriminator], [Password_Encriptada], [Password_Valor]) VALUES (3, N'MroUno', N'ApeMroUno', N'mrouno@gmail.com', N'Miembro', N'f4035833cb911a3e8634903e498ff84b05d4b66f73c6155af3f58b22ad3503f4', N'Admin123.')
INSERT [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Email], [Discriminator], [Password_Encriptada], [Password_Valor]) VALUES (4, N'MroDos', N'ApeMroDos', N'mrodos@gmail.com', N'Miembro', N'b4d36e8e34ad2575bfdba231f4091a39bf78c0eac815466ab5012df209dedc31', N'Admin234.')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
