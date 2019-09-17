CREATE TABLE [dbo].[tblMusician]
(
	[MusicianId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [LoginEmail] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [Band/MusicianName] VARCHAR(50) NOT NULL, 
    [SongId] UNIQUEIDENTIFIER NULL, 
    [Phone] VARCHAR(50) NULL, 
    [ContactEmail] VARCHAR(50) NULL, 
    [Website] VARCHAR(50) NULL, 
    [ProfileImage] VARCHAR(50) NULL
)
