namespace Supermarket.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }  
        public virtual List<Receipt> Receipts { get; set; }
        public bool IsActive { get; set; }
    }
}
