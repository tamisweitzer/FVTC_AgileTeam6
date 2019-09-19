BEGIN
	DECLARE @Players uniqueidentifier;
	DECLARE @Performers uniqueidentifier;
	DECLARE @Singers uniqueidentifier;

	SELECT @Players = MusicianId FROM tblMusician WHERE [Band/MusicianName] = 'The Players';
	SELECT @Performers = MusicianId FROM tblMusician WHERE [Band/MusicianName] = 'The Performers';
	SELECT @Singers = MusicianId FROM tblMusician WHERE [Band/MusicianName] = 'The Singers';

	DECLARE @Bar1 uniqueidentifier;
	DECLARE @Bar2 uniqueidentifier;
	DECLARE @Bar3 uniqueidentifier;

	SELECT @Bar1 = VenueId from tblVenue WHERE VenueName = 'Bar1';
	SELECT @Bar2 = VenueId from tblVenue WHERE VenueName = 'Bar2';
	SELECT @Bar3 = VenueId from tblVenue WHERE VenueName = 'Bar3';

	INSERT INTO tblMusicianVenueEvent(Id, MusicianId, VenueId, EventTime)
	VALUES
	(NEWID(), @Players, @Bar1, '7 pm'),
	(NEWID(), @Performers, @Bar2, '8 pm'),
	(NEWID(), @Singers, @Bar3, '7:30 pm')
END
GO