SET IDENTITY_INSERT [dbo].[Client] ON
INSERT INTO [dbo].[Client] ([ClientID], [Birthday], [ClientName], [ClientState], [Email], [Emergency_Contact], [Genre], [NIF], [PhoneNumber], [Type_ClientID]) VALUES (1, N'1980-10-05 13:00:00', N'João', 1, N'joao@gmail.com', 964238991, 1, 493828953, 964238991, 1)
INSERT INTO [dbo].[Client] ([ClientID], [Birthday], [ClientName], [ClientState], [Email], [Emergency_Contact], [Genre], [NIF], [PhoneNumber], [Type_ClientID]) VALUES (2, N'1985-05-08 20:00:00', N'Luis', 1, N'luis@gmail.com', 963891279, 1, 982912031, 963891279, 2)
INSERT INTO [dbo].[Client] ([ClientID], [Birthday], [ClientName], [ClientState], [Email], [Emergency_Contact], [Genre], [NIF], [PhoneNumber], [Type_ClientID]) VALUES (3, N'1983-07-20 11:00:00', N'André', 1, N'andre@gmail.com', 962387429, 1, 234234231, 962387429, 3)
INSERT INTO [dbo].[Client] ([ClientID], [Birthday], [ClientName], [ClientState], [Email], [Emergency_Contact], [Genre], [NIF], [PhoneNumber], [Type_ClientID]) VALUES (4, N'1963-02-28 09:00:00', N'Maria', 1, N'maria@gmail.com', 962132344, 0, 940221312, 962132344, 3)
SET IDENTITY_INSERT [dbo].[Client] OFF
