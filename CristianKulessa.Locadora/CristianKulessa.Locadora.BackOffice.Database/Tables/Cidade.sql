﻿CREATE TABLE [dbo].[Cidade]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[UFId] INT NOT NULL,
	[Nome] varchar(50) NOT NULL DEFAULT '',
	CONSTRAINT [FK_Cidade_UF] FOREIGN KEY (UFId) REFERENCES [UF]([Id]), 
)
