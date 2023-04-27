USE [receptkonyv]
GO
SET IDENTITY_INSERT [dbo].[kategoria] ON 
GO
INSERT [dbo].[kategoria] ([id], [nev]) VALUES (1, N'előétel')
GO
INSERT [dbo].[kategoria] ([id], [nev]) VALUES (2, N'leves')
GO
INSERT [dbo].[kategoria] ([id], [nev]) VALUES (3, N'édesség')
GO
INSERT [dbo].[kategoria] ([id], [nev]) VALUES (4, N'saláta')
GO
SET IDENTITY_INSERT [dbo].[kategoria] OFF
GO
SET IDENTITY_INSERT [dbo].[recept] ON 
GO
INSERT [dbo].[recept] ([id], [nev], [kat_id], [kep_eleresi_ut], [datum], [leiras]) VALUES (1, N'recept_1', 1, N'https://raketa.hu/uploads/2021/02/iman-1459322_1280.jpg', CAST(N'2023-04-27' AS Date), N'a')
GO
INSERT [dbo].[recept] ([id], [nev], [kat_id], [kep_eleresi_ut], [datum], [leiras]) VALUES (2, N'recept_2', 1, N'https://raketa.hu/uploads/2021/02/iman-1459322_1280.jpg', CAST(N'2023-04-27' AS Date), N'b')
GO
INSERT [dbo].[recept] ([id], [nev], [kat_id], [kep_eleresi_ut], [datum], [leiras]) VALUES (3, N'recept_3', 2, N'https://raketa.hu/uploads/2021/02/iman-1459322_1280.jpg', CAST(N'2023-04-27' AS Date), N'c')
GO
SET IDENTITY_INSERT [dbo].[recept] OFF
GO
