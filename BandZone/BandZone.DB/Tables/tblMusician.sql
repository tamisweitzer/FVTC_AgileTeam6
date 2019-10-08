CREATE TABLE [dbo].[tblMusician]
(
	[MusicianId] INT NOT NULL PRIMARY KEY, 
    [BandMusicianName] VARCHAR(50) NOT NULL, 
    [SongId] INT NULL, 
    [Phone] VARCHAR(50) NULL, 
    [ContactEmail] VARCHAR(50) NULL, 
    [Website] VARCHAR(50) NULL, 
    [ProfileImage] VARCHAR(50) NULL, 
    [LoginEmail] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(32) NOT NULL, 
    [Description] VARCHAR(256) NULL
)
