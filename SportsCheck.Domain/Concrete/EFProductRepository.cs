using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsCheck.Domain.Abstract;
using SportsCheck.Domain.Entities;

namespace SportsCheck.Domain.Concrete
{
   public class EFProductRepository:IProductsRepository 
    {
       private EFDbContext context = new EFDbContext();

       public IEnumerable<Product> Products
       {
           get { return context.Products; }
       }
       
    }
}
