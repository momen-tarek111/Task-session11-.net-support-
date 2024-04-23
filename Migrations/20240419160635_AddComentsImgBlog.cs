using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project3.Migrations
{
    /// <inheritdoc />
    public partial class AddComentsImgBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "coments",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coments",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Blogs");
        }
    }
}
