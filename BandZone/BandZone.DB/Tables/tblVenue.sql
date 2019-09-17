CREATE TABLE [dbo].[tblVenue]
(
	[VenueId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Password] NVARCHAR(50) NOT NULL, 
    [VenueName] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [OpenTime] NVARCHAR(50) NOT NULL, 
    [CloseTime] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [ProfileImage] NVARCHAR(50) NULL
)
