using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    cliente_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    documento = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    correo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.cliente_id);
                });

            migrationBuilder.CreateTable(
                name: "repuestos",
                columns: table => new
                {
                    repuesto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_repuestos", x => x.repuesto_id);
                });

            migrationBuilder.CreateTable(
                name: "roles_usuarios",
                columns: table => new
                {
                    rol_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_usuarios", x => x.rol_id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_servicios",
                columns: table => new
                {
                    tipo_servicio_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_servicios", x => x.tipo_servicio_id);
                });

            migrationBuilder.CreateTable(
                name: "vehiculos",
                columns: table => new
                {
                    vehiculo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    marca = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    modelo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    vin = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    kilometraje = table.Column<double>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculos", x => x.vehiculo_id);
                    table.ForeignKey(
                        name: "FK_vehiculos_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "cliente_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rol_id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    documento = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_usuarios_rol_id",
                        column: x => x.rol_id,
                        principalTable: "roles_usuarios",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "auditorias",
                columns: table => new
                {
                    auditoria_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    entidad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    accion = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auditorias", x => x.auditoria_id);
                    table.ForeignKey(
                        name: "FK_auditorias_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ordenes_servicios",
                columns: table => new
                {
                    orden_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehiculo_id = table.Column<int>(type: "int", nullable: false),
                    tipo_servicio_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: true),
                    fecha_ingreso = table.Column<DateTime>(type: "timestamp", nullable: false),
                    fecha_estimada = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes_servicios", x => x.orden_id);
                    table.ForeignKey(
                        name: "FK_ordenes_servicios_tipos_servicios_tipo_servicio_id",
                        column: x => x.tipo_servicio_id,
                        principalTable: "tipos_servicios",
                        principalColumn: "tipo_servicio_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordenes_servicios_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordenes_servicios_vehiculos_vehiculo_id",
                        column: x => x.vehiculo_id,
                        principalTable: "vehiculos",
                        principalColumn: "vehiculo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalles_ordenes",
                columns: table => new
                {
                    detalle_orden_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrdenServicioId = table.Column<int>(type: "int", nullable: false),
                    RepuestoId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_total = table.Column<double>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalles_ordenes", x => x.detalle_orden_id);
                    table.ForeignKey(
                        name: "FK_detalles_ordenes_ordenes_servicios_OrdenServicioId",
                        column: x => x.OrdenServicioId,
                        principalTable: "ordenes_servicios",
                        principalColumn: "orden_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalles_ordenes_repuestos_RepuestoId",
                        column: x => x.RepuestoId,
                        principalTable: "repuestos",
                        principalColumn: "repuesto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "facturas",
                columns: table => new
                {
                    factura_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrdenServicioId = table.Column<int>(type: "int", nullable: false),
                    monto_total = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    mano_obra = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    valor_total = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facturas", x => x.factura_id);
                    table.ForeignKey(
                        name: "FK_facturas_ordenes_servicios_OrdenServicioId",
                        column: x => x.OrdenServicioId,
                        principalTable: "ordenes_servicios",
                        principalColumn: "orden_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_auditorias_usuario_id",
                table: "auditorias",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_documento",
                table: "clientes",
                column: "documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalles_ordenes_OrdenServicioId",
                table: "detalles_ordenes",
                column: "OrdenServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_detalles_ordenes_RepuestoId",
                table: "detalles_ordenes",
                column: "RepuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_facturas_OrdenServicioId",
                table: "facturas",
                column: "OrdenServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_servicios_tipo_servicio_id",
                table: "ordenes_servicios",
                column: "tipo_servicio_id");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_servicios_usuario_id",
                table: "ordenes_servicios",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_servicios_vehiculo_id",
                table: "ordenes_servicios",
                column: "vehiculo_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_correo",
                table: "usuarios",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_rol_id",
                table: "usuarios",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_cliente_id",
                table: "vehiculos",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_vin",
                table: "vehiculos",
                column: "vin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auditorias");

            migrationBuilder.DropTable(
                name: "detalles_ordenes");

            migrationBuilder.DropTable(
                name: "facturas");

            migrationBuilder.DropTable(
                name: "repuestos");

            migrationBuilder.DropTable(
                name: "ordenes_servicios");

            migrationBuilder.DropTable(
                name: "tipos_servicios");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "vehiculos");

            migrationBuilder.DropTable(
                name: "roles_usuarios");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
