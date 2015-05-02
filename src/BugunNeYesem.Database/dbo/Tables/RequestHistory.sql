CREATE TABLE [dbo].[RequestHistory]
(
	[Id]				INT             IDENTITY (1, 1) NOT NULL, 
    [CreatedDate]		DATETIME						NULL, 
    [Query]				NVARCHAR(MAX)					NULL, 
    [QueryResult]		XML								NULL, 
    [QueryDate]		    DATETIME						NULL, 
)
