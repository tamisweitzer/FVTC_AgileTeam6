BEGIN
	INSERT INTO tblVenue(VenueId, Password, VenueName, Address, City, OpenTime, CloseTime, Email, Phone, ProfileImage)
	VALUES
	(NEWID(), 'test4', 'Bar1', '001 Test St.', 'Kaukauna', '11 am', '2 am', NULL, '920-000-0004', 'logo4.PNG'),
	(NEWID(), 'test5', 'Bar2', '002 Test St.', 'Appleton', '11 am', '2 am', NULL, '920-000-0005', 'logo5.PNG'),
	(NEWID(), 'test6', 'Bar3', '003 Test St.', 'Kimberly', '11 am', '2 am', NULL, '920-000-0006', 'logo6.PNG')
END
GO