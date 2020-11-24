using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeThings.Web.Models
{
    public class AddNewItemResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ItemModel AddedItem { get; set; }
    }
}
