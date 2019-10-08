BEGIN
	INSERT INTO tblMusician(MusicianId, LoginEmail, Password, BandMusicianName, SongId, Phone, ContactEmail, Website, ProfileImage, Description)
	VALUES
	(1, 'test1@test.com', 'test1', 'The Players', 1, '920-000-0001', 'contact1@contact.com', NULL, 'logo1.PNG', 'We play'),
	(2, 'test2@test.com', 'test2', 'The Performers', 2, '920-000-002', 'contact2@contact.com', 'facebook.com', 'logo2.PNG', 'We perform'),
	(3, 'test3@test.com', 'test3', 'The Singers', 3, '920-000-0003', 'contact3@contact.com', NULL, 'logo3.PNG', 'We sing')
END
GO