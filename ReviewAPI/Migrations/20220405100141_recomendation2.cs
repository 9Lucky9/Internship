using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewAPI.Migrations
{
    public partial class recomendation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Games " +
                "SET Genre = 'Рекомендовано ' + Genre " +
                "FROM Games where Games.genre = 'Шутер'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
