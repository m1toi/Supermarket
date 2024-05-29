namespace Supermarket.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ProducerName { get; set; }

        public string CategoryName { get; set; }
      
       
    }
}
