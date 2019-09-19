BEGIN

	DECLARE @Song1Id uniqueidentifier;
	DECLARE @Song2Id uniqueidentifier;
	DECLARE @Song3Id uniqueidentifier;

	SELECT @Song1Id = SongId FROM tblSong WHERE SongName = 'Playing';
	SELECT @Song2Id = SongId FROM tblSong WHERE SongName = 'Performing';
	SELECT @Song3Id = SongId FROM tblSong WHERE SongName = 'Singing';

	INSERT INTO tblMusician(MusicianId, LoginEmail, Password, [Band/MusicianName], SongId, Phone, ContactEmail, Website, ProfileImage)
	VALUES
	(NEWID(), 'test1@test.com', 'test1', 'The Players', @Song1Id, '920-000-0001', 'contact1@contact.com', NULL, 'logo1.PNG'),
	(NEWID(), 'test2@test.com', 'test2', 'The Performers', @Song2Id, '920-000-002', 'contact2@contact.com', 'facebook.com', 'logo2.PNG'),
	(NEWID(), 'test3@test.com', 'test3', 'The Singers', @Song3Id, '920-000-0003', 'contact3@contact.com', NULL, 'logo3.PNG')
END
GO