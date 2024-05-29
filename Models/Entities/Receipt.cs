using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Models.Entities
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal AmountReceived { get; set; }
        [NotMapped]
        public virtual List<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
