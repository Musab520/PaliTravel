IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'michael.brown@example.com')
    BEGIN
    -- Inserting data into the Users table
    INSERT INTO Users (Id, Email, PasswordHash, FirstName, LastName, UserRole)
    VALUES
        (NEWID(), 'michael.brown@example.com', 'hashedpassword789', 'Michael', 'Brown', 'Admin'),
        (NEWID(), 'lucy.jones@example.com', 'hashedpassword012', 'Lucy', 'Jones', 'User');
    
    -- Inserting data into the City table
    INSERT INTO City (Id, Name, Country, PostOffice, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), 'Paris', 'France', '75001', GETDATE(), GETDATE()),
        (NEWID(), 'Berlin', 'Germany', '10115', GETDATE(), GETDATE());
    
    -- Inserting data into the Hotel table
    INSERT INTO Hotel (Id, Name, StarRating, Owner, CityId, Latitude, Longitude, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), 'Hotel Royale', 4, 'Michael Brown Holdings', (SELECT Id FROM City WHERE Name = 'Paris'), 48.8566, 2.3522, GETDATE(), GETDATE()),
        (NEWID(), 'The Berlin Suites', 3, 'Lucy Jones Hotels', (SELECT Id FROM City WHERE Name = 'Berlin'), 52.5200, 13.4050, GETDATE(), GETDATE());
    
    -- Inserting data into the Room table
    INSERT INTO Room (Id, HotelId, RoomNumber, Availability, AdultCapacity, ChildCapacity, Price, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'Hotel Royale'), 102, 'Available', 2, 1, 180.00, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Hotel WHERE Name = 'The Berlin Suites'), 202, 'Available', 2, 2, 230.00, GETDATE(), GETDATE());
    
    -- Inserting data into the Deal table
    INSERT INTO Deal (Id, RoomId, FromDate, ToDate, Discount, CreatedOn, UpdateOn)
    VALUES
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 102), '2025-05-01', '2025-05-10', 0.20, GETDATE(), GETDATE()),
        (NEWID(), (SELECT Id FROM Room WHERE RoomNumber = 202), '2025-06-01', '2025-06-10', 0.15, GETDATE(), GETDATE());
END