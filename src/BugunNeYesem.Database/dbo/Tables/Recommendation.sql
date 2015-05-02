CREATE TABLE [dbo].[Recommendation]
(
	[Id]				INT             IDENTITY (1, 1) NOT NULL, 
    [CreatedDate]		DATETIME						NULL, 
	[VenueId]			INT								NULL, 
    [VenueName]			NVARCHAR(150)					NULL, 
)
