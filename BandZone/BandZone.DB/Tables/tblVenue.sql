CREATE TABLE [dbo].[tblVenue]
(
	[VenueId] INT NOT NULL PRIMARY KEY, 
    [VenueName] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [OpenTime] NVARCHAR(50) NOT NULL, 
    [CloseTime] NVARCHAR(50) NOT NULL, 
    [ContactEmail] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [ProfileImage] NVARCHAR(50) NULL, 
    [LoginEmail] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(32) NOT NULL
)
