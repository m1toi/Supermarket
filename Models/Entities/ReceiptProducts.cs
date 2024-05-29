using Microsoft.EntityFrameworkCore;

namespace Supermarket.Models.Entities
{
    [PrimaryKey("ReceiptId", "ProductId")]
    public class ReceiptProducts
    {
        public int ReceiptId { get; set; }
        public virtual Receipt Receipt { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal SubtotalPrice { get; set; }
        public bool IsActive { get; set; }  
    }
}
