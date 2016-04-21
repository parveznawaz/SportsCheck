using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using SportsCheck.Domain.Abstract;
using SportsCheck.Domain.Entities;
using SportsCheck.Domain.Concrete;

namespace SportsCheck.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
        {
            private IKernel kernel;
            public NinjectDependencyResolver(IKernel kernelParam)
            {
                kernel = kernelParam;
                AddBindings();
            }
            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }
            private void AddBindings()
            {
                // put bindings here
                Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
                mock.Setup(m => m.Products).Returns(new List<Product> { 
                    new Product{Name="Football", Price=25},
                    new Product{Name="Surf board", Price=179},
                    new Product{Name="Running shoes", Price=95}
                });
                //bind kernel to mock object
                //kernel.Bind<IProductsRepository>().ToConstant(mock.Object);
                //bind kernel to Product repository db
                kernel.Bind<IProductsRepository>().To<EFProductRepository>();
            }
        }
    
}