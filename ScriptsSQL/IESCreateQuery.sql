USE [InformatorioEvaluationSystem]
GO
/****** Object:  ForeignKey [FK_dbo.Answers_dbo.Questions_Question_ID]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_dbo.Answers_dbo.Questions_Question_ID]
GO
/****** Object:  ForeignKey [FK_dbo.Questions_dbo.Tests_Test_ID]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_dbo.Questions_dbo.Tests_Test_ID]
GO
/****** Object:  ForeignKey [FK_dbo.Users_dbo.Tests_Test_ID]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_dbo.Users_dbo.Tests_Test_ID]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_dbo.Answers_dbo.Questions_Question_ID]
GO
DROP TABLE [dbo].[Answers]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_dbo.Questions_dbo.Tests_Test_ID]
GO
DROP TABLE [dbo].[Questions]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_dbo.Users_dbo.Tests_Test_ID]
GO
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/23/2014 00:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Lastname] [nvarchar](max) NOT NULL,
	[DNI] [nvarchar](8) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Studies] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[Province] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[RegisterDate] [datetime] NOT NULL,
	[HasTakenTest] [bit] NOT NULL,
	[TestResult] [int] NOT NULL,
	[Test_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([ID], [Name], [Lastname], [DNI], [Date], [Studies], [Email], [Phone], [Province], [City], [Password], [RegisterDate], [HasTakenTest], [TestResult], [Test_ID]) VALUES (1, N'Fernando', N'Luján', N'30517936', CAST(0x0000779300000000 AS DateTime), N'Universitario', N'lujanfernandogabriel@gmail.com', N'3794007733', N'Corrientes', N'Corrientes', N'79360000FL', CAST(0x0000A2BA01278261 AS DateTime), 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[Questions]    Script Date: 01/23/2014 00:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[question] [nvarchar](max) NULL,
	[Test_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Questions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Questions] ON
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (1, N'El resultado de multiplicar 25*25 es...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (2, N'Piensa en el número 125, divídelo entre 5, vuélvelo a dividir por 5, y vuélvelo a dividir por 5. ¿Cuál es el resultado?', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (3, N'Piensa en el número 456, multiplícalo por 4, divídelo entre 6, y réstale 35. ¿Cuál es es resultado?', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (4, N'El resultado de dividir 8500 entre 5 es...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (5, N'El 6 por ciento de 3500 es ...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (6, N'Eleva 300 al cuadrado. El resultado es...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (7, N'El 15 por ciento de 8000 es ...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (8, N'Realiza la siguiente operación: 5+16+23+90-100+135', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (9, N'Calcula el 35% de 1000', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (10, N'El número resultante de elevar 6 al cubo es ...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (11, N'El número resultante de elevar 16 al cuadrado es ...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (12, N'Realiza la siguiente operación: (9/3)+(5+16)+(3+2)+(80/5)', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (13, N'NULLRealiza la siguiente operación: 5 + -51 + 31 + -3', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (14, N'Partiendo del número 1000, ¿Cuántas veces puedes dividir entre 8, siempre teniendo como resultado un entero?', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (15, N'Descuenta el 20 por ciento a 4000, el resultado es...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (16, N'El 99 por cien de 2000 es ...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (17, N'Realiza la siguiente operación: (5+6)+(3+9)-(5+5)', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (18, N'Descuenta el 40 por ciento a 8000, el resultado es...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (19, N'El 5 por mil de 800 es ...', 1)
INSERT [dbo].[Questions] ([ID], [question], [Test_ID]) VALUES (20, N'Partiendo del número 500, ¿Cuántas veces puedes dividir entre 5, siempre teniendo como resultado un entero?', 1)
SET IDENTITY_INSERT [dbo].[Questions] OFF
/****** Object:  Table [dbo].[Answers]    Script Date: 01/23/2014 00:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[answer] [nvarchar](max) NULL,
	[Type] [bit] NOT NULL,
	[Question_ID] [int] NULL,
 CONSTRAINT [PK_dbo.Answers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answers] ON
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (1, N'2500', 1, 1)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (2, N'625', 0, 1)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (3, N'825', 0, 1)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (4, N'1', 1, 2)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (5, N'25', 0, 2)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (6, N'5', 0, 2)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (7, N'269', 1, 3)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (8, N'369', 0, 3)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (9, N'520', 0, 3)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (10, N'1400', 1, 4)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (11, N'1500', 0, 4)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (12, N'1700', 0, 4)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (13, N'110', 1, 5)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (14, N'310', 0, 5)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (15, N'210', 0, 5)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (16, N'9000', 1, 6)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (17, N'90000', 0, 6)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (18, N'18000', 0, 6)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (19, N'1000', 1, 7)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (20, N'1200', 0, 7)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (21, N'800', 0, 7)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (22, N'140', 1, 8)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (23, N'169', 0, 8)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (24, N'79', 0, 8)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (25, N'350', 1, 9)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (26, N'650', 0, 9)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (27, N'250', 0, 9)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (28, N'116', 1, 10)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (29, N'316', 0, 10)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (30, N'216', 0, 10)
SET IDENTITY_INSERT [dbo].[Answers] OFF
/****** Object:  ForeignKey [FK_dbo.Answers_dbo.Questions_Question_ID]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Answers_dbo.Questions_Question_ID] FOREIGN KEY([Question_ID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_dbo.Answers_dbo.Questions_Question_ID]
GO
/****** Object:  ForeignKey [FK_dbo.Questions_dbo.Tests_Test_ID]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Questions_dbo.Tests_Test_ID] FOREIGN KEY([Test_ID])
REFERENCES [dbo].[Tests] ([ID])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_dbo.Questions_dbo.Tests_Test_ID]
GO
/****** Object:  ForeignKey [FK_dbo.Users_dbo.Tests_Test_ID]    Script Date: 01/23/2014 00:26:39 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Tests_Test_ID] FOREIGN KEY([Test_ID])
REFERENCES [dbo].[Tests] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Tests_Test_ID]
GO
