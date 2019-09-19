BEGIN
	INSERT INTO tblGenre(GenreId, GenreType)
	VALUES
	(NEWID(), 'Country'),
	(NEWID(), 'Hip Hop'),
	(NEWID(), 'Rock'),
	(NEWID(), 'Alternative'),
	(NEWID(), 'Mix & Variety'),
	(NEWID(), 'Gospel'),
	(NEWID(), 'Reggae'),
	(NEWID(), 'Latino')
END
GO