/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Andar');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Apartamento');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Casa');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Cobertura');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Flat');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Galpão');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Hotel');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Loft');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Prédio');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Sala Comercial');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Salão Comercial');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Sobrado');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Sobreloja');
INSERT INTO [dbo].[Tipo] ([Nome])VALUES('Terreno');

INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Acre','AC');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Alagoas','AL');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Amapá','AP');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Amazonas','AM');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Bahia','BA');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Ceará','CE');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Espírito Santo','ES');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Goiás','GO');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Maranhão','MA');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Mato Grosso','MT');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Mato Grosso do Sul','MS');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Minas Gerais','MG');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Pará','PA');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Paraíba','PB');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Paraná','PR');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Pernambuco','PE');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Piauí','PI');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Rio de Janeiro','RJ');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Rio Grande do Norte','RN');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Rio Grande do Sul','RS');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Rondônia','RO');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Roraima','RR');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Santa Catarina','SC');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('São Paulo','SP');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Sergipe','SE');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Tocantins','TO');
INSERT INTO [dbo].[UF] ([Nome],[Sigla]) VALUES ('Distrito Federal','DF');
