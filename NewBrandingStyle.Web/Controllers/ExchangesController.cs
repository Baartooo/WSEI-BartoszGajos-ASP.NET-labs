using ExchangeThings.Web.Database;
using ExchangeThings.Web.Filters;
using ExchangeThings.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeThings.Web.Controllers
{
    public class ExchangesController : Controller
    {

        private readonly ExchangesDbContext _dbContext;

        public ExchangesController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [ServiceFilter(typeof(MyCustomActionFilter))]
        public IActionResult Show(string id)
        {
            return View();
        }

        [HttpGet("ItemsList")]
        public IActionResult ItemsList()
        {
            var items = _dbContext.Items.ToList();

            return Ok(items);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ItemModel item)
        {
            //TODO add to database

            var viewModel = new AddNewItemConfirmationViewModel
            {
                Id = 1,
                Name = item.Name
            };

            //return View("AddConfirmation", viewModel);

            return RedirectToAction("AddConfirmation");
        }

        [HttpGet]
        public IActionResult AddConfirmation()
        {
            return View();
        }
    }
}
