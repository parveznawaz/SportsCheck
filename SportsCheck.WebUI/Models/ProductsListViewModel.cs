using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsCheck.Domain.Entities;

namespace SportsCheck.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCatagory { get; set; }
    }
}