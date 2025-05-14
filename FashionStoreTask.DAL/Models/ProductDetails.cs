using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreTask.DAL.Models
{
   public class ProductDetails : BaseModel
    {
        public int? StockCount { get; set; }
        
        public string? LongDescription { get; set; }

        public int? ProductID { get; set; }
        public Product? product { get; set; }
    }
}
