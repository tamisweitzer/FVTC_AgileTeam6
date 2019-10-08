CREATE TABLE [dbo].[tblMusicianVenueEvent]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MusicianId] INT NOT NULL, 
    [VenueId] INT NOT NULL, 
    [EventTime] VARCHAR(50) NOT NULL
)
