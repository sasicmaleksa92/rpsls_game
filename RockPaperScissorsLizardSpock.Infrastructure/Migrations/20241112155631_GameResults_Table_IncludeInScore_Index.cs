using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RockPaperScissorsLizardSpock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GameResults_Table_IncludeInScore_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GameResult_IncludeInScore",
                table: "GameResult",
                column: "IncludeInScore");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IX_GameResult_IncludeInScore");
        }

    }
}
