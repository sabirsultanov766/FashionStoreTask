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
    public class ProductServices
    {
        private readonly AppDBContext _context;

        public ProductServices()
        {
            _context = new AppDBContext();
        }

        public void Create(ProductPostVM productPostVM)
        {
            Product product = new Product();

            product.Name = productPostVM.Name;
            product.Price = productPostVM.Price;
            product.ShortDescription = productPostVM.ShortDescription;
            product.IsNew = productPostVM.IsNew;

            string fileName = Path.GetFileNameWithoutExtension(productPostVM.Image.FileName);
            string extension = Path.GetExtension(productPostVM.Image.FileName);
            string fullPath = fileName + Guid.NewGuid().ToString() + extension;
            product.ImgUrl = fullPath;

            string path = @"C:\Users\Sabir\source\repos\FashionStoreTask\FashionStoreTask.MVC\wwwroot\assets\UploadedImages";
            path = Path.Combine(path, fullPath);
            using FileStream stream = new FileStream(path, FileMode.Create);
            productPostVM.Image.CopyTo(stream);


            _context.Add(product);
            _context.SaveChanges();

        }
        public Product GetProductById(int id)
        {
            var product = _context.products.Find(id);
            return product;
        }
        public List<Product> GetAllProducts()
        {
            var list = _context.products.ToList();
            return list;
        }
        public void Update(int id, ProductUpdateVM productUpdateVM)
        {
            Product product = GetProductById(id);

            product.Name = productUpdateVM.Name;
            product.Price = productUpdateVM.Price;
            product.ShortDescription = productUpdateVM.ShortDescription;
            product.IsNew = productUpdateVM.IsNew;

            if (productUpdateVM.Image is not null)
            {
                string fileName = Path.GetFileNameWithoutExtension(productUpdateVM.Image.FileName);
                string extension = Path.GetExtension(productUpdateVM.Image.FileName);
                string fullPath = fileName + Guid.NewGuid().ToString() + extension;
                product.ImgUrl = fullPath;

                string path = @"C:\Users\Sabir\source\repos\FashionStoreTask\FashionStoreTask.MVC\wwwroot\assets\UploadedImages";
                path = Path.Combine(path, fullPath);
                using FileStream stream = new FileStream(path, FileMode.Create);
                productUpdateVM.Image.CopyTo(stream);
            }

            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = GetProductById(id);
            if (File.Exists(@"C:\\Users\\Sabir\\source\\repos\\FashionStoreTask\\FashionStoreTask.MVC\\wwwroot\\assets\\UploadedImages" + product.ImgUrl))
            {
                File.Delete(@"C:\\Users\\Sabir\\source\\repos\\FashionStoreTask\\FashionStoreTask.MVC\\wwwroot\\assets\\UploadedImages" + product.ImgUrl);
            }

            _context.Remove(product);
        }
    }
}
