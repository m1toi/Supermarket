using Microsoft.Identity.Client;

namespace Supermarket.Models.Entities
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
        public virtual List<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
