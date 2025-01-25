using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitHotelTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE Hotel (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "Name NVARCHAR(MAX) NOT NULL, " +
                                 "StarRating NVARCHAR(MAX) NOT NULL, " +
                                 "CityId UNIQUEIDENTIFIER NOT NULL, " +
                                 "Latitude DECIMAL(18, 2) NULL," +
                                 "Longitude DECIMAL(18, 2) NULL," +
                                 "CreatedOn DATETIME2 NOT NULL, " +
                                 "UpdateDate DATETIME2 NOT NULL," + 
                                 "CONSTRAINT FK_Hotel_CityId FOREIGN KEY (CityId) REFERENCES City(Id)" +
                                 ");");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");
        }
    }
}