BEGIN
	INSERT INTO tblVenue(VenueId, VenueName, Address, City, OpenTime, CloseTime, ContactEmail, Phone, ProfileImage, LoginEmail, Password)
	VALUES
	(1, 'Bar1', '001 Test St.', 'Kaukauna', '11 am', '2 am', NULL, '920-000-0004', 'logo4.PNG', 'venue1@gmail.com', 'pass1'),
	(2, 'Bar2', '002 Test St.', 'Appleton', '11 am', '2 am', NULL, '920-000-0005', 'logo5.PNG', 'venue2@gmail.com', 'pass2'),
	(3, 'Bar3', '003 Test St.', 'Kimberly', '11 am', '2 am', NULL, '920-000-0006', 'logo6.PNG', 'venue3@gmail.com', 'pass3')
END
GO