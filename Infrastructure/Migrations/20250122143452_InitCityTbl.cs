using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaliTravel.Migrations
{
    /// <inheritdoc />
    public partial class InitCityTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE City (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "Name NVARCHAR(MAX) NOT NULL, " +
                                 "Country NVARCHAR(MAX) NOT NULL, " +
                                 "PostOffice NVARCHAR(MAX) NULL, " +
                                 "CreatedOn DATETIME2 NULL, " +
                                 "UpdateDate DATETIME2 NULL" + 
                                ");");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
