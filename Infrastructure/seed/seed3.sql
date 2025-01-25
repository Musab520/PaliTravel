IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'olivia.martin@example.com')
    BEGIN
    -- Inserting data into the Users table
    INSERT INTO Users (Id, Email, PasswordHash, FirstName, LastName, UserRole)
    VALUES
        (NEWID(), 'olivia.martin@example.com', 'hashedpassword987', 'Olivia', 'Martin', 'Admin'),
        (NEWID(), 'charlie.wilson@example.com', 'hashedpassword654', 'Charlie', 'Wilson', 'User');
    
    -- Inserting data into the City table
    INSERT INTO City (Id, Name, Country, PostOffice, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), 'Sydney', 'Australia', '2000', GETDATE(), GETDATE()),
        (NEWID(), 'Tokyo', 'Japan', '100-0001', GETDATE(), GETDATE());
    
    -- Inserting data into the Hotel table
    INSERT INTO Hotel (Id, Name, StarRating, Owner, CityId, Latitude, Longitude, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), 'Sydney Grand', 5, 'Olivia Martin Group', (SELECT Id FROM City WHERE Name = 'Sydney'), -33.8688, 151.2093, GETDATE(), GETDATE()),
        (NEWID(), 'Tokyo View Hotel', 3, 'Charlie Wilson Hotels', (SELECT Id FROM City WHERE Name = 'Tokyo'), 35.6762, 139.6503, GETDATE(), GETDATE());
    
    -- Inserting data into the Room table
    INSERT INTO Room (Id, HotelId, RoomNumber, Availability, AdultCapacity, ChildCapacity, Price, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Sydney Grand'), 103, 'Available', 2, 2, 350.00, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Tokyo View Hotel'), 203, 'Available', 2, 1, 210.00, GETDATE(), GETDATE());
    
    -- Inserting data into the Deal table
    INSERT INTO Deal (Id, RoomId, FromDate, ToDate, Discount, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 103), '2025-07-01', '2025-07-15', 0.25, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 203), '2025-08-01', '2025-08-15', 0.12, GETDATE(), GETDATE());
END