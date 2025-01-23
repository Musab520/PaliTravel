using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaliTravel.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerColumnInHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE Hotel
                ADD Owner NVARCHAR(MAX) NULL;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE Hotel
                DROP COLUMN Owner;
            ");
        }
    }
}
