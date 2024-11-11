using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buy_sell_system.Migrations
{
    /// <inheritdoc />
    public partial class AddTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Countries_CountryName",
                table: "Countries",
                column: "CountryName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Countries_CountryName",
                table: "Countries");
        }
    }
}
