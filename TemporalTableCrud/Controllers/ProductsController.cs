using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TemporalTableCrud.Contexts;
using TemporalTableCrud.Models;

namespace TemporalTableCrud.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext context;

        public ProductsController(ProductDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index(DateTime? historyDateTime)
        {
            if (historyDateTime.HasValue)
            {
                var sql = "SELECT * FROM Products FOR SYSTEM_TIME FROM {0} TO {1} ORDER BY Id, ValidFrom ";
                var products = context.Products
                    .FromSqlRaw(sql, historyDateTime.Value.Date, historyDateTime.Value.Date.AddDays(1).AddTicks(-1))
                    .AsNoTracking()
                    .ToList();

                return View(products);
            }

            return View(context.Products.ToList());
        }

        [HttpGet]
        public IActionResult Create() => View(new Product { Id = 0 });

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var product = context.Products.Find(productId);
            return View("Create", product);
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            context.Products.Update(product);

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
