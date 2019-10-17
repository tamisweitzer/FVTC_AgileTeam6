/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*DROP TABLE IF EXISTS [dbo].[tblSearchLog]*/
DROP TABLE IF EXISTS [dbo].[tblGenre]
DROP TABLE IF EXISTS [dbo].[tblMusician]
DROP TABLE IF EXISTS [dbo].[tblMusicGenre]
DROP TABLE IF EXISTS [dbo].[tblMusicianVenueEvent]
DROP TABLE IF EXISTS [dbo].[tblSong]
DROP TABLE IF EXISTS [dbo].[tblSongGenre]
DROP TABLE IF EXISTS [dbo].[tblVenue]