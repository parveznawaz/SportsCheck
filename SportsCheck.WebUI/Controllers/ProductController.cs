using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsCheck.Domain.Abstract;
using SportsCheck.Domain.Entities;
using SportsCheck.WebUI.Models;

namespace SportsCheck.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository  repository;
        public int PageSize = 4;

        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }
        
       
        public ViewResult List(string catagory, int page=1)
        {
            //return View(repository.Products
            //    .OrderBy(p=>p.ProductID)
            //    .Skip((page-1)*PageSize)
            //    .Take(PageSize));
            Console.WriteLine(catagory);
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p=>p.Category==catagory)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                ,PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                },
                CurrentCatagory=catagory
            };
            return View(model);
        }
    }
}