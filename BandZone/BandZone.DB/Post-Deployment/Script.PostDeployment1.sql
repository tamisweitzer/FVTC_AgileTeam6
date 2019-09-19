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

--Tables that don't rely on others
:r .\DefaultData\Musicians.sql
:r .\DefaultData\Song.sql
:r .\DefaultData\Venue.sql
:r .\DefaultData\BandZoneGenre.sql

--Uses Musician, Genre
:r .\DefaultData\MusicianGenre.sql
GO

--Uses Song, Genre
:r .\DefaultData\SongGenre.sql
GO

--Uses Musician, Venue
:r .\DefaultData\MusicianVenueEvent.sql
GO