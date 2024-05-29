using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        [NotMapped]
        public virtual List<Receipt> Receipts { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual List<Stock> Stocks { get; set; }
        public bool IsActive { get; set; } 
    }
}
