using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEf.Application.Migrations
{
    /// <inheritdoc />
    public partial class Update_RowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TestEfEntities",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TestEfEntities");
        }
    }
}
