using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureClicker.Migrations
{
    /// <inheritdoc />
    public partial class SharedUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfileApplicationData");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ProfileApplicationData",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProfileApplicationData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProfileApplicationData",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
