using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockPaperScissorsLizardSpock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GameResult_Table_IncludeInScore_Column_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IncludeInScore",
                schema: "dbo",
                table: "GameResult",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncludeInScore",
                schema: "dbo",
                table: "GameResult");

        }
    }
}
