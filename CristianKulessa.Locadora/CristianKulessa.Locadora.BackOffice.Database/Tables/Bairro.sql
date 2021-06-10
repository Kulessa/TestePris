CREATE TABLE [dbo].[Bairro]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CidadeId] INT NOT NULL,
	[Nome] varchar(50) NOT NULL DEFAULT '',
	CONSTRAINT [FK_Bairro_Cidade] FOREIGN KEY (CidadeId) REFERENCES [Cidade]([Id]),
)
