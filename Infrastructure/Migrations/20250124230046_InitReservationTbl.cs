using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaliTravel.Migrations
{
    
    public partial class InitReservationTbl : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE Reservation (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "RoomId UNIQUEIDENTIFIER NOT NULL, " +
                                 "HotelId UNIQUEIDENTIFIER NOT NULL, " +
                                 "CheckIn DATETIME2 NOT NULL, " +
                                 "CheckOut DATETIME2 NOT NULL," +
                                 "PricePurchased DECIMAL(18, 2) NOT NULL," +
                                 "CreatedOn DATETIME2 NOT NULL, " +
                                 "UpdateOn DATETIME2 NOT NULL," +
                                 "CONSTRAINT FK_Reservation_HotelId FOREIGN KEY (HotelId) REFERENCES Hotel(Id)," +
                                 "CONSTRAINT FK_Reservation_RoomId FOREIGN KEY (RoomId) REFERENCES Room(Id)," +
                                 "CONSTRAINT UQ_RoomId_HotelId UNIQUE (HotelId, RoomId)" +
                                 ");");
        }
        
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");
        }
    }
}