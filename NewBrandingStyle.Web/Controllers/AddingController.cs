using ExchangeThings.Web.Database;
using ExchangeThings.Web.Entities;
using ExchangeThings.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeThings.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddingController : ControllerBase
    {

        private readonly ExchangesDbContext _dbContext;

        public AddingController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AddNewItemResponse Post(ItemModel item)
        {
            var entity = new ItemEntity
            {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible,
            };

            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();

            var response = new AddNewItemResponse()
            {
                IsSuccess = true,
                Message = "you did it",
                AddedItem = item
            };

            return response;
        }

    }


}
