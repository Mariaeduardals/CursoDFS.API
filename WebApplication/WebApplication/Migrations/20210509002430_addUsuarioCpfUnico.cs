using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class addUsuarioCpfUnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Usuario_UsuarioCpf",
                table: "Compra");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Usuario_Email_Password",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Compra_UsuarioCpf",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "UsuarioCpf",
                table: "Compra");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Compra",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Companhia",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(18)",
                oldMaxLength: 18);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Usuario_Cpf",
                table: "Usuario",
                column: "Cpf");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Usuario_Email",
                table: "Usuario",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Companhia_Cnpj",
                table: "Companhia",
                column: "Cnpj");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UsuarioId",
                table: "Compra",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Usuario_UsuarioId",
                table: "Compra",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Usuario_UsuarioId",
                table: "Compra");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Usuario_Cpf",
                table: "Usuario");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Usuario_Email",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Compra_UsuarioId",
                table: "Compra");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Companhia_Cnpj",
                table: "Companhia");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Compra");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCpf",
                table: "Compra",
                type: "character varying(11)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Companhia",
                type: "character varying(18)",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Usuario_Email_Password",
                table: "Usuario",
                columns: new[] { "Email", "Password" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_UsuarioCpf",
                table: "Compra",
                column: "UsuarioCpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Usuario_UsuarioCpf",
                table: "Compra",
                column: "UsuarioCpf",
                principalTable: "Usuario",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
