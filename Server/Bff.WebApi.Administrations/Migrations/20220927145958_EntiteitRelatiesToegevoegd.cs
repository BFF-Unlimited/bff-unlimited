using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bff.WebApi.Services.Administrations.Migrations
{
    public partial class EntiteitRelatiesToegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Permissions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notities",
                newName: "NotitieId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Leerlingen",
                newName: "LeerlingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LaatstBekekenPaginas",
                newName: "LaatstBekekenPaginaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Absenties",
                newName: "AbsentieId");

            migrationBuilder.AddColumn<Guid>(
                name: "PermissionId",
                table: "Permissions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "PermissionId");

            migrationBuilder.CreateTable(
                name: "Vestiging",
                columns: table => new
                {
                    VestigingId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vestiging", x => x.VestigingId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Groep",
                columns: table => new
                {
                    GroepId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VestigingId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groep", x => x.GroepId);
                    table.ForeignKey(
                        name: "FK_Groep_Vestiging_VestigingId",
                        column: x => x.VestigingId,
                        principalTable: "Vestiging",
                        principalColumn: "VestigingId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notities_LeerlingId",
                table: "Notities",
                column: "LeerlingId");

            migrationBuilder.CreateIndex(
                name: "IX_Leerlingen_GroepId",
                table: "Leerlingen",
                column: "GroepId");

            migrationBuilder.CreateIndex(
                name: "IX_LaatstBekekenPaginas_PermissionId",
                table: "LaatstBekekenPaginas",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_LaatstBekekenPaginas_UserId",
                table: "LaatstBekekenPaginas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Absenties_LeerlingId",
                table: "Absenties",
                column: "LeerlingId");

            migrationBuilder.CreateIndex(
                name: "IX_Groep_VestigingId",
                table: "Groep",
                column: "VestigingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absenties_Leerlingen_LeerlingId",
                table: "Absenties",
                column: "LeerlingId",
                principalTable: "Leerlingen",
                principalColumn: "LeerlingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LaatstBekekenPaginas_Permissions_PermissionId",
                table: "LaatstBekekenPaginas",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LaatstBekekenPaginas_Users_UserId",
                table: "LaatstBekekenPaginas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leerlingen_Groep_GroepId",
                table: "Leerlingen",
                column: "GroepId",
                principalTable: "Groep",
                principalColumn: "GroepId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notities_Leerlingen_LeerlingId",
                table: "Notities",
                column: "LeerlingId",
                principalTable: "Leerlingen",
                principalColumn: "LeerlingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absenties_Leerlingen_LeerlingId",
                table: "Absenties");

            migrationBuilder.DropForeignKey(
                name: "FK_LaatstBekekenPaginas_Permissions_PermissionId",
                table: "LaatstBekekenPaginas");

            migrationBuilder.DropForeignKey(
                name: "FK_LaatstBekekenPaginas_Users_UserId",
                table: "LaatstBekekenPaginas");

            migrationBuilder.DropForeignKey(
                name: "FK_Leerlingen_Groep_GroepId",
                table: "Leerlingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Notities_Leerlingen_LeerlingId",
                table: "Notities");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_UserId",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "Groep");

            migrationBuilder.DropTable(
                name: "Vestiging");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Notities_LeerlingId",
                table: "Notities");

            migrationBuilder.DropIndex(
                name: "IX_Leerlingen_GroepId",
                table: "Leerlingen");

            migrationBuilder.DropIndex(
                name: "IX_LaatstBekekenPaginas_PermissionId",
                table: "LaatstBekekenPaginas");

            migrationBuilder.DropIndex(
                name: "IX_LaatstBekekenPaginas_UserId",
                table: "LaatstBekekenPaginas");

            migrationBuilder.DropIndex(
                name: "IX_Absenties_LeerlingId",
                table: "Absenties");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Permissions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Permissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NotitieId",
                table: "Notities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LeerlingId",
                table: "Leerlingen",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LaatstBekekenPaginaId",
                table: "LaatstBekekenPaginas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AbsentieId",
                table: "Absenties",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");
        }
    }
}
