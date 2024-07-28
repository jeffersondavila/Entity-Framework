using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pro.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CodigoCategoria", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076502"), "", "Actividades activas", 2 },
                    { new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b5207657b"), "", "Actividades pendientes", 1 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "CodigoTarea", "CodigoCategoria", "Descripcon", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076510"), new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b5207657b"), "", new DateTime(2024, 7, 28, 8, 58, 22, 39, DateTimeKind.Local).AddTicks(1429), 1, "Pago servicios publico" },
                    { new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076520"), new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b5207657b"), "", new DateTime(2024, 7, 28, 8, 58, 22, 39, DateTimeKind.Local).AddTicks(1444), 2, "Pago servicios privados" },
                    { new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076530"), new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076502"), "", new DateTime(2024, 7, 28, 8, 58, 22, 39, DateTimeKind.Local).AddTicks(1447), 2, "Pago U" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "CodigoTarea",
                keyValue: new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076510"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "CodigoTarea",
                keyValue: new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076520"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "CodigoTarea",
                keyValue: new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076530"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CodigoCategoria",
                keyValue: new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b52076502"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CodigoCategoria",
                keyValue: new Guid("ee877ebe-14e2-4ad2-aa4f-bf4b5207657b"));
        }
    }
}
