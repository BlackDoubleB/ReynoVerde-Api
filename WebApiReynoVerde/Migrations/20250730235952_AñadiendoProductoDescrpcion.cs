using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiReynoVerde.Migrations
{
    /// <inheritdoc />
    public partial class AñadiendoProductoDescrpcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductoDescripcion",
                table: "Producto",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "Defauly");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoDescripcion",
                table: "Producto");
        }
    }
}
