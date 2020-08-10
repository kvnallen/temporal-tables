using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TemporalTableCrud.Models;

namespace TemporalTableCrud.Migrations
{
    public partial class AddDefaultItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var products = new []
            {
                "Smartphone",
                "Mouse",
                "Teclado",
                "Monitor",
                "Cadeira",
                "Mesa",
                "Fone",
                "Porta",
            };

            InsertData(migrationBuilder, products);


        }

        private void InsertData(MigrationBuilder mb, IEnumerable<string> products)
        {
            foreach (var product in products)
            {
                mb.InsertData(
                        table: "Products",
                        columns: new[] { "Name" },
                        values: new[] { product  });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
