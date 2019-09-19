BEGIN
	INSERT INTO tblSong(SongId, SongName)
	VALUES
	(NEWID(), 'Playing'),
	(NEWID(), 'Performing'),
	(NEWID(), 'Singing')
END
GO