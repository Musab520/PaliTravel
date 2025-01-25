IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'olivia.martin@example.com')
    BEGIN

    INSERT INTO Users (Id, Email, PasswordHash, FirstName, LastName, UserRole)
    VALUES
        (NEWID(), 'olivia.martin@example.com', 'hashedpassword987', 'Olivia', 'Martin', 'Admin'),
        (NEWID(), 'charlie.wilson@example.com', 'hashedpassword654', 'Charlie', 'Wilson', 'User');
    

    INSERT INTO City (Id, Name, Country, PostOffice, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), 'Sydney', 'Australia', '2000', GETDATE(), GETDATE()),
        (NEWID(), 'Tokyo', 'Japan', '100-0001', GETDATE(), GETDATE());
    

    INSERT INTO Hotel (Id, Name, StarRating, Owner, CityId, Latitude, Longitude, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), 'Sydney Grand', 5, 'Olivia Martin Group', (SELECT Id FROM City WHERE Name = 'Sydney'), -33.8688, 151.2093, GETDATE(), GETDATE()),
        (NEWID(), 'Tokyo View Hotel', 3, 'Charlie Wilson Hotels', (SELECT Id FROM City WHERE Name = 'Tokyo'), 35.6762, 139.6503, GETDATE(), GETDATE());
    

    INSERT INTO Room (Id, HotelId, RoomNumber, Availability, AdultCapacity, ChildCapacity, Price, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Sydney Grand'), 103, 'Reserved', 2, 2, 350.00, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Tokyo View Hotel'), 203, 'Reserved', 2, 1, 210.00, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Sydney Grand'), 144, 'Free', 2, 2, 350.00, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Tokyo View Hotel'), 244, 'Free', 2, 1, 210.00, GETDATE(), GETDATE());
    

    INSERT INTO Deal (Id, RoomId, FromDate, ToDate, Discount, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 103), '2025-07-01', '2025-07-15', 0.25, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 203), '2025-08-01', '2025-08-15', 0.12, GETDATE(), GETDATE());

    INSERT INTO Reservation (Id, RoomId, DealId, CheckIn, CheckOut, PricePurchased, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 103), (SELECT Id FROM Deal WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 103)), '2025-07-01', '2025-07-05', 262.50, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 203), (SELECT Id FROM Deal WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 203)), '2025-08-01', '2025-08-05', 184.80, GETDATE(), GETDATE());


    INSERT INTO Confirmation (Id, ConfirmationNumber, ReservationId, DealId, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), NEWID(), (SELECT Id FROM Reservation WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 103)), (SELECT Id FROM Deal WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 103)), GETDATE(), GETDATE()),
        (NEWID(), NEWID(), (SELECT Id FROM Reservation WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 203)), (SELECT Id FROM Deal WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 203)), GETDATE(), GETDATE());
END