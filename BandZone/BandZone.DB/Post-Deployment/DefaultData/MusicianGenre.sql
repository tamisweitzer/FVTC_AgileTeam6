BEGIN
	DECLARE @Players uniqueidentifier;
	DECLARE @Performers uniqueidentifier;
	DECLARE @Singers uniqueidentifier;


	SELECT @Players = MusicianId FROM tblMusician WHERE [Band/MusicianName] = 'The Players';
	SELECT @Performers = MusicianId FROM tblMusician WHERE [Band/MusicianName] = 'The Performers';
	SELECT @Singers = MusicianId FROM tblMusician WHERE [Band/MusicianName] = 'The Singers';

	DECLARE @Country uniqueidentifier;
	DECLARE @Rock uniqueidentifier;
	DECLARE @Latino uniqueidentifier;
	DECLARE @Alternative uniqueidentifier;

	SELECT @Country = GenreId FROM tblGenre WHERE GenreType = 'Country';
	SELECT @Rock = GenreId FROM tblGenre WHERE GenreType = 'Rock';
	SELECT @Latino = GenreId FROM tblGenre WHERE GenreType = 'Latino';
	SELECT @Alternative = GenreId FROM tblGenre WHERE GenreType = 'Alternative';


	INSERT INTO tblMusicGenre(Id, MusicianId, GenreId)
	VALUES
	(NEWID(), @Players, @Country),
	(NEWID(), @Performers, @Rock),
	(NEWID(), @Performers, @Alternative),
	(NEWID(), @Singers, @Latino)
END
GO