namespace Supermarket.Models.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public bool IsActive { get; set; }
    }
}
