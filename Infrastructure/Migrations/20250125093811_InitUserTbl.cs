using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitUserTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TABLE Users (" + 
                                 "Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, " +
                                 "Email NVARCHAR(MAX) NOT NULL, " +
                                 "PasswordHash NVARCHAR(MAX) NOT NULL, " +
                                 "FirstName NVARCHAR(MAX) NOT NULL, " +
                                 "LastName NVARCHAR(MAX) NULL, " +
                                 "UserRole NVARCHAR(36) NOT NULL" + 
                                 ");");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
