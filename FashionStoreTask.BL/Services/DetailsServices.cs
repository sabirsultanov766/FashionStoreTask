using FashionStoreTask.BL.ViewModels;
using FashionStoreTask.DAL.Contexts;
using FashionStoreTask.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreTask.BL.Services
{
    public class DetailsServices
    {
        private readonly AppDBContext _context;
        private readonly ProductServices _services;
        public DetailsServices()
        {
            _context = new AppDBContext();
            _services = new ProductServices();
            
        }
        

        public void DetailsCreate(int ProductId,ProductDetails productDetails)
        {
            Product product = _services.GetProductById(ProductId);
            product.productDetails = productDetails;
            
            productDetails.product = product;

            _context.productDetails.Add(productDetails);
            _context.SaveChanges();

        }
        public ProductDetails GetProductDetailsById(int ProductDetailsId)
        {
           var details = _context.productDetails.Find(ProductDetailsId);
            return details;
        }
        public void UpdateProductDetails(int ProductDetailsId,ProductDetails productDetails)
        {
            var details = GetProductDetailsById(ProductDetailsId);

            details.StockCount = productDetails.StockCount;
            details.LongDescription = productDetails.LongDescription;

            _context.SaveChanges();
        }
        public void DeleteProductDetails(int productDetailsId)
        {
            var details = GetProductDetailsById(productDetailsId);
            _context.productDetails.Remove(details);
        }
    }
}
