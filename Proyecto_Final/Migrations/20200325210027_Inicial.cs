using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto_Final.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cacaos",
                columns: table => new
                {
                    CacaoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntradaId = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cacaos", x => x.CacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ContratoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaVencimiento = table.Column<DateTime>(nullable: false),
                    CantidadTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratoId);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    EntradaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    SuplidorId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.EntradaId);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.PagoId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true),
                    NombreUsuario = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "PagosDetalle",
                columns: table => new
                {
                    PagoDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PagoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    TipoCacao = table.Column<string>(nullable: true),
                    Cantidad = table.Column<decimal>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosDetalle", x => x.PagoDetalleId);
                    table.ForeignKey(
                        name: "FK_PagosDetalle_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagosDetalle_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalle",
                columns: table => new
                {
                    VentaDetalleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(nullable: false),
                    ContratoId = table.Column<int>(nullable: false),
                    CantidadCacao = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalle", x => x.VentaDetalleId);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Contratos_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contratos",
                        principalColumn: "ContratoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentasDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Clave", "Email", "NombreUsuario", "Nombres" },
                values: new object[] { 1, "Admin", "Admin@outlook.com", "Admin", "Administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_PagosDetalle_ClienteId",
                table: "PagosDetalle",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosDetalle_PagoId",
                table: "PagosDetalle",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_ContratoId",
                table: "VentasDetalle",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalle_VentaId",
                table: "VentasDetalle",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cacaos");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "PagosDetalle");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VentasDetalle");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
