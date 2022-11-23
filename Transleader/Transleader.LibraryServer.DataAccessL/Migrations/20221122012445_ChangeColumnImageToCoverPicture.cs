using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transleader.LibraryServer.DataAccessL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnImageToCoverPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Books",
                newName: "CoverPicture"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
