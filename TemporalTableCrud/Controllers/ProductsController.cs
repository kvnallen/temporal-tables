using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemporalTableCrud.Contexts;
using TemporalTableCrud.Models;

namespace TemporalTableCrud.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromServices] ProductDbContext context,
            DateTime? historyDateTime)
        {
            if (historyDateTime.HasValue)
            {
                var sql = $"SELECT * FROM Products FOR SYSTEM_TIME FROM {{0}} TO {{1}}";
                var products = context.Products
                    .FromSqlRaw(sql, historyDateTime.Value.Date, historyDateTime.Value.Date.AddDays(1).AddTicks(-1))
                    .AsNoTracking()
                    .ToList();

                return View(products);
            }

            return View(context.Products.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
