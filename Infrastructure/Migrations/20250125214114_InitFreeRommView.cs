using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitFreeRommView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE VIEW AvailableRooms AS
        SELECT 
            r.Id AS RoomId,
            r.HotelId,
            h.Name AS HotelName,
            r.RoomNumber,
            r.Price,
            COALESCE(d.Discount, 0) AS Discount,
            CASE 
                WHEN d.Discount > 0 THEN CAST(1 AS BIT) 
                ELSE CAST(0 AS BIT) 
            END AS IsDiscounted,
            d.FromDate AS DiscountStartDate,
            d.ToDate AS DiscountEndDate,
            r.Availability,
            r.AdultCapacity,
            r.ChildCapacity,
            r.CreatedOn,
            r.UpdateOn
        FROM 
            Room r
        INNER JOIN 
            Hotel h ON r.HotelId = h.Id
        LEFT JOIN 
            Deal d ON r.Id = d.RoomId 
            AND GETDATE() BETWEEN d.FromDate AND d.ToDate
        WHERE 
            r.Availability = 'Free';
    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS AvailableRooms;");
        }
    }
}