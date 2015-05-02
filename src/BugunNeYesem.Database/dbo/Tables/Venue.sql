CREATE TABLE [dbo].[Venue]
(
	[Id]				INT             IDENTITY (1, 1) NOT NULL, 
    [CreatedDate]		DATETIME						NULL, 
    [Name]				NVARCHAR(150)					NULL, 
    [Contact]			NVARCHAR(150)					NULL, 
    [Location]			NVARCHAR(1000)					NULL, 
    [Url]				NVARCHAR(150)					NULL, 
    [Price]				DECIMAL(18, 2)					NULL, 
    [Rating]			DECIMAL(18, 2)					NULL, 
    [Description]		NVARCHAR(1000)					NULL, 
    [CreatedAt]			DATETIME						NULL, 
    [Likes]				INT								NULL, 
    [Attributes]		NVARCHAR(500)					NULL,
)
