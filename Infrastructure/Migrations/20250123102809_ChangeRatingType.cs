using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaliTravel.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRatingType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        ALTER TABLE Hotel
        DROP COLUMN StarRating;
    ");

            migrationBuilder.Sql(@"
        ALTER TABLE Hotel
        ADD StarRating INT NOT NULL DEFAULT 1;
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        ALTER TABLE Hotel
        DROP COLUMN StarRating;
    ");

            migrationBuilder.Sql(@"
        ALTER TABLE Hotel
        ADD StarRating NVARCHAR(MAX) NOT NULL DEFAULT '';
    ");
        }
    }
}