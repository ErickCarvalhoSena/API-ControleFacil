using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFacil.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNullable : Migration
    {
        /// <inheritdoc />
       protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AlterColumn<DateTime>(
        name: "DataRecebimento",
        table: "areceber",
        type: "timestamp",
        nullable: true,
        oldClrType: typeof(DateTime),
        oldType: "timestamp",
        oldNullable: false);

    migrationBuilder.AlterColumn<DateTime>(
        name: "DataReferencia",
        table: "areceber",
        type: "timestamp",
        nullable: true,
        oldClrType: typeof(DateTime),
        oldType: "timestamp",
        oldNullable: false);
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.AlterColumn<DateTime>(
        name: "DataRecebimento",
        table: "areceber",
        type: "timestamp",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp",
        oldNullable: true);

    migrationBuilder.AlterColumn<DateTime>(
        name: "DataReferencia",
        table: "areceber",
        type: "timestamp",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp",
        oldNullable: true);
}
    }
}
