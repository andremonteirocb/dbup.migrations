CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](150) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Telefone] [varchar](100) NOT NULL
) ON [PRIMARY]