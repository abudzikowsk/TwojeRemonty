using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwojeRemonty.Migrations
{
    public partial class Addtittlefieldtoofferschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tittle",
                table: "Offers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tittle",
                table: "Offers");
        }
    }
}
