using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDealTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE Deal (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "RoomId UNIQUEIDENTIFIER NOT NULL, " +
                                 "HotelId UNIQUEIDENTIFIER NOT NULL, " +
                                 "FromDate DATETIME2 NOT NULL, " +
                                 "ToDate DATETIME2 NOT NULL," +
                                 "Discount FLOAT NOT NULL," +
                                 "CreatedOn DATETIME2 NOT NULL, " +
                                 "UpdateOn DATETIME2 NOT NULL," +
                                 "CONSTRAINT FK_Deal_HotelId FOREIGN KEY (HotelId) REFERENCES Hotel(Id)," +
                                 "CONSTRAINT FK_Deal_RoomId FOREIGN KEY (RoomId) REFERENCES Room(Id)," +
                                 "CONSTRAINT UQ_RoomId_HotelId_Deal UNIQUE (HotelId, RoomId)" +
                                 ");");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deal");
        }
    }
}