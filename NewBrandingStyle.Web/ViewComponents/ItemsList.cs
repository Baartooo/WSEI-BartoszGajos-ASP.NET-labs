using ExchangeThings.Web.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeThings.Web.ViewComponents
{
    public class ItemsList : ViewComponent
    {
        private readonly ExchangesDbContext _dbContext;


        public ItemsList(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IViewComponentResult Invoke()
        {
            var items = _dbContext.Items.ToList();

            return View("Index", items);
        }
    }
}
