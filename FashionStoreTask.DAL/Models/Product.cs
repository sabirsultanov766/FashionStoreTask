using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreTask.DAL.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string ShortDescription { get; set; }
        public string? ImgUrl { get; set;}
        public bool IsNew { get; set; }

        public int? ProductDetailsID { get; set; }
        [ForeignKey("ProductDetailsID")]

        public ProductDetails? productDetails { get; set; } 
    }
}
