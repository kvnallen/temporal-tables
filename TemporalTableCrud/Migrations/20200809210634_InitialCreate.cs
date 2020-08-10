using Microsoft.EntityFrameworkCore.Migrations;

namespace TemporalTableCrud.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.Sql(@"ALTER TABLE Products ADD 
                    ValidFrom datetime2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
                    ValidTo   datetime2 GENERATED ALWAYS AS ROW END HIDDEN NOT NULL,
                    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo);");

              migrationBuilder.Sql($@"ALTER TABLE Products
                    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.ProductHistory));");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
