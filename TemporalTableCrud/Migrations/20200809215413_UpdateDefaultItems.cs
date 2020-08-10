using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TemporalTableCrud.Migrations
{
    public partial class UpdateDefaultItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            UpdateData(migrationBuilder);
        }


        private void UpdateData(MigrationBuilder mb)
        {
            mb.Sql($"UPDATE Products SET Name = concat( Name  , ' - Atualizado')");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
