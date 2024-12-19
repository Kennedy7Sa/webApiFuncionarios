using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionarioWebApi.Migrations
{
    /// <inheritdoc />
    public partial class tirandoCedilha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeAlteração",
                table: "Funcionarios",
                newName: "DataDeAlteracao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeAlteracao",
                table: "Funcionarios",
                newName: "DataDeAlteração");
        }
    }
}
