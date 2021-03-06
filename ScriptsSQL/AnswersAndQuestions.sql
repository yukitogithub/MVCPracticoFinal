USE [InformatorioEvaluationSystem]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 02/02/2014 22:44:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[question] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Questions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Questions] ON
INSERT [dbo].[Questions] ([ID], [question]) VALUES (1, N'El resultado de multiplicar 25*25 es...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (2, N'Piensa en el número 125, divídelo entre 5, vuélvelo a dividir por 5, y vuélvelo a dividir por 5. ¿Cuál es el resultado?')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (3, N'Piensa en el número 456, multiplícalo por 4, divídelo entre 6, y réstale 35. ¿Cuál es es resultado?')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (4, N'El resultado de dividir 8500 entre 5 es...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (5, N'El 6 por ciento de 3500 es ...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (6, N'Eleva 300 al cuadrado. El resultado es...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (7, N'El 15 por ciento de 8000 es ...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (8, N'Realiza la siguiente operación: 5+16+23+90-100+135')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (9, N'Calcula el 35% de 1000')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (10, N'El número resultante de elevar 6 al cubo es ...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (11, N'El número resultante de elevar 16 al cuadrado es ...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (12, N'Realiza la siguiente operación: (9/3)+(5+16)+(3+2)+(80/5)')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (13, N'Realiza la siguiente operación: 5 + -51 + 31 + -3')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (14, N'Partiendo del número 1000, ¿Cuántas veces puedes dividir entre 8, siempre teniendo como resultado un entero?')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (15, N'Descuenta el 20 por ciento a 4000, el resultado es...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (16, N'El 99 por cien de 2000 es ...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (17, N'Realiza la siguiente operación: (5+6)+(3+9)-(5+5)')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (18, N'Descuenta el 40 por ciento a 8000, el resultado es...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (19, N'El 5 porciento de 800 es ...')
INSERT [dbo].[Questions] ([ID], [question]) VALUES (20, N'Partiendo del número 500, ¿Cuántas veces puedes dividir entre 5, siempre teniendo como resultado un entero?')
SET IDENTITY_INSERT [dbo].[Questions] OFF
/****** Object:  Table [dbo].[Answers]    Script Date: 02/02/2014 22:44:53 ******/
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
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (1, N'2500', 0, 1)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (2, N'625', 1, 1)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (3, N'825', 0, 1)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (4, N'1', 1, 2)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (5, N'25', 0, 2)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (6, N'5', 0, 2)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (7, N'520', 0, 3)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (8, N'369', 0, 3)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (9, N'269', 1, 3)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (10, N'1400', 0, 4)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (11, N'1500', 0, 4)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (12, N'1700', 1, 4)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (13, N'110', 0, 5)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (14, N'210', 1, 5)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (15, N'310', 0, 5)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (16, N'9000', 0, 6)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (17, N'90000', 1, 6)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (18, N'18000', 0, 6)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (19, N'1000', 0, 7)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (20, N'800', 1, 7)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (21, N'1200', 0, 7)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (22, N'169', 1, 8)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (23, N'140', 0, 8)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (24, N'79', 0, 8)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (25, N'250', 0, 9)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (26, N'650', 0, 9)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (27, N'350', 1, 9)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (28, N'116', 0, 10)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (29, N'316', 0, 10)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (30, N'216', 1, 10)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (31, N'256', 1, 11)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (32, N'456', 0, 11)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (33, N'216', 0, 11)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (34, N'35', 0, 12)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (35, N'45', 1, 12)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (36, N'55', 0, 12)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (37, N'18', 0, 13)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (38, N'-18', 1, 13)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (39, N'-12', 0, 13)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (40, N'1', 1, 14)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (41, N'2', 0, 14)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (42, N'3', 0, 14)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (43, N'800', 0, 15)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (44, N'3200', 1, 15)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (45, N'1200', 0, 15)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (46, N'20', 0, 16)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (47, N'1890', 0, 16)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (48, N'1980', 1, 16)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (49, N'13', 1, 17)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (50, N'10', 0, 17)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (51, N'23', 0, 17)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (52, N'3800', 0, 18)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (53, N'4800', 1, 18)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (54, N'3200', 0, 18)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (55, N'40', 1, 19)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (56, N'48', 0, 19)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (57, N'46', 0, 19)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (58, N'3', 1, 20)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (59, N'2', 0, 20)
INSERT [dbo].[Answers] ([ID], [answer], [Type], [Question_ID]) VALUES (60, N'1', 0, 20)
SET IDENTITY_INSERT [dbo].[Answers] OFF
/****** Object:  ForeignKey [FK_dbo.Answers_dbo.Questions_Question_ID]    Script Date: 02/02/2014 22:44:53 ******/
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Answers_dbo.Questions_Question_ID] FOREIGN KEY([Question_ID])
REFERENCES [dbo].[Questions] ([ID])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_dbo.Answers_dbo.Questions_Question_ID]
GO
