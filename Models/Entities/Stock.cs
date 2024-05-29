using System.ComponentModel.DataAnnotations.Schema;
using Supermarket.Services;

namespace Supermarket.Models.Entities
{
    public class Stock
    {
        public int? StockId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime SupplyDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal PurchasePrice { get; set; }
        [NotMapped]
        public decimal SellingPrice => PurchasePrice * (decimal)1.2;
        public bool IsActive { get; set; }  
    }
}
