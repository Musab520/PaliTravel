using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaliTravel.Migrations
{
    /// <inheritdoc />
    public partial class InitRoomTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE Room (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "HotelId UNIQUEIDENTIFIER NOT NULL, " +
                                 "RoomNumber INT NOT NULL, " +
                                 "Availability NVARCHAR(MAX) NOT NULL, " +
                                 "AdultCapacity INT NULL," +
                                 "ChildCapacity INT NULL," +
                                 "Price DECIMAL(18, 2) NOT NULL," +
                                 "CreatedOn DATETIME2 NOT NULL, " +
                                 "UpdateDate DATETIME2 NOT NULL," + 
                                 "CONSTRAINT FK_Room_HotelId FOREIGN KEY (HotelId) REFERENCES Hotel(Id)," +
                                 "CONSTRAINT UQ_Room_HotelId_RoomNumber UNIQUE (HotelId, RoomNumber)" +
                                 ");");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}