SET IDENTITY_INSERT [dbo].[Question] ON
INSERT INTO [dbo].[Question] ([QuestionID], [QuestionState], [QuestionToClient]) VALUES (1, 1, N'Qual é a sua idade?')
INSERT INTO [dbo].[Question] ([QuestionID], [QuestionState], [QuestionToClient]) VALUES (2, 0, N'Qual é a sua altura?')
INSERT INTO [dbo].[Question] ([QuestionID], [QuestionState], [QuestionToClient]) VALUES (3, 1, N'Tem doenças?')
SET IDENTITY_INSERT [dbo].[Question] OFF
