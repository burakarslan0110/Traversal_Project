using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class acoounttoguides : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideID",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_GuideID",
                table: "Accounts",
                column: "GuideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Guides_GuideID",
                table: "Accounts",
                column: "GuideID",
                principalTable: "Guides",
                principalColumn: "GuideID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Guides_GuideID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_GuideID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "GuideID",
                table: "Accounts");
        }
    }
}
