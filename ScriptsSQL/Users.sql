INSERT INTO [InformatorioEvaluationSystem].[dbo].[Users]
           ([Name]
           ,[Lastname]
           ,[DNI]
           ,[Date]
           ,[Studies]
           ,[Email]
           ,[Phone]
           ,[Province]
           ,[City]
           ,[Password]
           ,[RegisterDate]
           ,[HasTakenTest]
           ,[Test_ID])
     VALUES 
     (N'Fernando'
	   , N'Luján'
	   , N'30517936'
	   , CAST(0x0000779300000000 AS DateTime)
	   , N'Universitario'
	   , N'lujanfernandogabriel@gmail.com'
	   , N'3794007733'
	   , N'Corrientes'
	   , N'Corrientes'
	   , N'79360000FL'
	   , CAST(0x0000A2BA01278261 AS DateTime)
	   , 0
	   , NULL)
GO
