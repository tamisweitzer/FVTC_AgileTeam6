BEGIN
	INSERT INTO tblMusicianVenueEvent(Id, MusicianId, VenueId, EventTime)
	VALUES
	(1, 1, 1, '7 pm'),
	(2, 2, 2, '8 pm'),
	(3, 3, 3, '7:30 pm')
END
GO