IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'john.doe@example.com')
    BEGIN
    -- Inserting data into the Users table
    INSERT INTO Users (Id, Email, PasswordHash, FirstName, LastName, UserRole)
    VALUES
        (NEWID(), 'john.doe@example.com', 'hashedpassword123', 'John', 'Doe', 'Admin'),
        (NEWID(), 'jane.smith@example.com', 'hashedpassword456', 'Jane', 'Smith', 'User');
    
    -- Inserting data into the City table
    INSERT INTO City (Id, Name, Country, PostOffice, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), 'New York', 'USA', '10001', GETDATE(), GETDATE()),
        (NEWID(), 'London', 'UK', 'E1 6AN', GETDATE(), GETDATE());
    
    -- Inserting data into the Hotel table
    INSERT INTO Hotel (Id, Name, StarRating, Owner, CityId, Latitude, Longitude, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), 'Hotel Central', 5, 'John Doe Enterprises', (SELECT Id FROM City WHERE Name = 'New York'), 40.7128, -74.0060, GETDATE(), GETDATE()),
        (NEWID(), 'Luxury Stay', 4, 'Jane Smith Group', (SELECT Id FROM City WHERE Name = 'London'), 51.5074, -0.1278, GETDATE(), GETDATE());
    
    -- Inserting data into the Room table
    INSERT INTO Room (Id, HotelId, RoomNumber, Availability, AdultCapacity, ChildCapacity, Price, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Hotel Central'), 101, 'Free', 2, 1, 200.00, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Luxury Stay'), 111, 'Free', 2, 1, 200.00, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Hotel Central'), 201, 'Free', 2, 2, 250.00, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Luxury Stay'), 222, 'Free', 2, 2, 250.00, GETDATE(), GETDATE());
    
    -- Inserting data into the Deal table
    INSERT INTO Deal (Id, RoomId, FromDate, ToDate, Discount, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 101), '2025-02-01', '2025-02-10', 0.15, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 201), '2025-03-01', '2025-03-15', 0.10, GETDATE(), GETDATE());

    INSERT INTO Reservation (Id, RoomId, DealId, CheckIn, CheckOut, PricePurchased, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 101), (SELECT Id FROM Deal WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 101)), '2025-07-01', '2025-07-05', 262.50, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 201), (SELECT Id FROM Deal WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 201)), '2025-08-01', '2025-08-05', 184.80, GETDATE(), GETDATE());

-- Inserting data into the Confirmation table
    INSERT INTO Confirmation (Id, ConfirmationNumber, ReservationId, DealId, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), NEWID(), (SELECT Id FROM Reservation WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 101)), (SELECT Id FROM Deal WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 101)), GETDATE(), GETDATE()),
        (NEWID(), NEWID(), (SELECT Id FROM Reservation WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 201)), (SELECT Id FROM Deal WHERE RoomId = (SELECT Id FROM Room WHERE RoomNumber = 201)), GETDATE(), GETDATE());
END