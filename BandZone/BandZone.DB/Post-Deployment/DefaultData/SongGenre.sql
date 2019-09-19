BEGIN
	DECLARE @Playing uniqueidentifier;
	DECLARE @Performing uniqueidentifier;
	DECLARE @Singing uniqueidentifier;


	SELECT @Playing = SongId FROM tblSong WHERE SongName = 'Playing';
	SELECT @Performing = SongId FROM tblSong WHERE SongName = 'Performing';
	SELECT @Singing = SongId FROM tblSong WHERE SongName = 'Singing';

	DECLARE @Country uniqueidentifier;
	DECLARE @Rock uniqueidentifier;
	DECLARE @Latino uniqueidentifier;
	DECLARE @Alternative uniqueidentifier;

	SELECT @Country = GenreId FROM tblGenre WHERE GenreType = 'Country';
	SELECT @Rock = GenreId FROM tblGenre WHERE GenreType = 'Rock';
	SELECT @Latino = GenreId FROM tblGenre WHERE GenreType = 'Latino';
	SELECT @Alternative = GenreId FROM tblGenre WHERE GenreType = 'Alternative';


	INSERT INTO tblSongGenre(Id, SongId, GenreId)
	VALUES
	(NEWID(), @Playing, @Country),
	(NEWID(), @Performing, @Rock),
	(NEWID(), @Performing, @Alternative),
	(NEWID(), @Singing, @Latino)
END
GO