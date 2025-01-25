migrationBuilder.Sql("CREATE TABLE Users (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "Email NVARCHAR(MAX) NOT NULL, " +
                                 "PasswordHash NVARCHAR(MAX) NOT NULL, " +
                                 "FirstName NVARCHAR(MAX) NOT NULL, " +
                                 "LastName NVARCHAR(MAX) NULL, " +
                                 "UserRole NVARCHAR(36) NOT NULL" + 
                                 ");");
                                 
                                 
migrationBuilder.Sql("CREATE TABLE City (" + 
                              "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                              "Name NVARCHAR(MAX) NOT NULL, " +
                              "Country NVARCHAR(MAX) NOT NULL, " +
                              "PostOffice NVARCHAR(MAX) NULL, " +
                              "CreatedOn DATETIME2 NULL, " +
                              "UpdateOn DATETIME2 NULL" + 
                              ");");

migrationBuilder.Sql("CREATE TABLE Hotel (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "Name NVARCHAR(MAX) NOT NULL, " +
                                 "StarRating INT NOT NULL, " +
                                 "Owner NVARCHAR(MAX) NULL," +
                                 "CityId UNIQUEIDENTIFIER NOT NULL, " +
                                 "Latitude DECIMAL(18, 2) NULL," +
                                 "Longitude DECIMAL(18, 2) NULL," +
                                 "CreatedOn DATETIME2 NOT NULL, " +
                                 "UpdateOn DATETIME2 NOT NULL," + 
                                 "CONSTRAINT FK_Hotel_CityId FOREIGN KEY (CityId) REFERENCES City(Id)" +
                                 ");");
migrationBuilder.Sql("CREATE TABLE Room (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "HotelId UNIQUEIDENTIFIER NOT NULL, " +
                                 "RoomNumber INT NOT NULL, " +
                                 "Availability NVARCHAR(MAX) NOT NULL, " +
                                 "AdultCapacity INT NULL," +
                                 "ChildCapacity INT NULL," +
                                 "Price DECIMAL(18, 2) NOT NULL," +
                                 "CreatedOn DATETIME2 NOT NULL, " +
                                 "UpdateOn DATETIME2 NOT NULL," + 
                                 "CONSTRAINT FK_Room_HotelId FOREIGN KEY (HotelId) REFERENCES Hotel(Id)," +
                                 "CONSTRAINT UQ_Room_HotelId_RoomNumber UNIQUE (HotelId, RoomNumber)" +
                                 ");");

migrationBuilder.Sql("CREATE TABLE Deal (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "RoomId UNIQUEIDENTIFIER NOT NULL, " +
                                 "FromDate DATETIME2 NOT NULL, " +
                                 "ToDate DATETIME2 NOT NULL," +
                                 "Discount FLOAT NOT NULL," +
                                 "CreatedOn DATETIME2 NOT NULL, " +
                                 "UpdateOn DATETIME2 NOT NULL," +
                                 "CONSTRAINT FK_Deal_RoomId FOREIGN KEY (RoomId) REFERENCES Room(Id)," +
                                 ");");
                    
migrationBuilder.Sql("CREATE TABLE Reservation (" + 
                     "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                     "RoomId UNIQUEIDENTIFIER NOT NULL, " +
                     "DealId UNIQUEIDENTIFIER NULL, " +
                     "CheckIn DATETIME2 NOT NULL, " +
                     "CheckOut DATETIME2 NOT NULL," +
                     "PricePurchased DECIMAL(18, 2) NOT NULL," +
                     "CreatedOn DATETIME2 NOT NULL, " +
                     "UpdateOn DATETIME2 NOT NULL," +
                     "CONSTRAINT FK_Reservation_RoomId FOREIGN KEY (RoomId) REFERENCES Room(Id)," +
                     "CONSTRAINT FK_Reservation_DealId FOREIGN KEY (DealId) REFERENCES Deal(Id)," +
                     ");");

migrationBuilder.Sql("CREATE TABLE Confirmation (" + 
                     "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                     "ConfirmationNumber UNIQUEIDENTIFIER NOT NULL, " +
                     "ReservationId UNIQUEIDENTIFIER NOT NULL," +
                     "DealId UNIQUEIDENTIFIER NULL," +
                     "CreatedOn DATETIME2 NOT NULL, " +
                     "UpdateOn DATETIME2 NOT NULL," +
                     "CONSTRAINT FK_Confirmation_ReservationId FOREIGN KEY (ReservationId) REFERENCES Reservation(Id)," +
                     "CONSTRAINT UQ_CofirmationNumber_ReservationId UNIQUE (ReservationId, ConfirmationNumber)" +
                     ");");