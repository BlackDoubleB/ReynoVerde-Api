using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiReynoVerde.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductoDescripcion",
                table: "Producto",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "Defauly",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldDefaultValue: "Defauly");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductoDescripcion",
                table: "Producto",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "Defauly",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldDefaultValue: "Defauly");
        }
    }
}
