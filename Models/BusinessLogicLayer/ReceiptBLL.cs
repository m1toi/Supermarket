using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.Entities;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ReceiptBLL
    {
        private readonly ReceiptDAL _receiptDAL;
        private readonly StockBLL _stockBLL = new StockBLL();
        private readonly ReceiptProductsDAL _receiptProducts = new ReceiptProductsDAL();
        public ObservableCollection<Stock> Stocks { get; set; }
        public ReceiptBLL()
        {
            _receiptDAL = new ReceiptDAL();
            Stocks = new ObservableCollection<Stock>();
            Stocks = _stockBLL.GetStocks();
        }
        public ObservableCollection<Receipt> GetReceipts()
        {
            ObservableCollection<Receipt> receipts = new ObservableCollection<Receipt>();
            foreach (var receipt in _receiptDAL.GetReceipts())
            {
                receipts.Add(receipt);
            }
            return receipts;
        }
        public void AddReceipt(ObservableCollection<ProductPrice> products)
        {
            
            Receipt receipt = new Receipt
            {

                UserId = 4,
                IssueDate = DateTime.Now,
                AmountReceived = products.Sum(p => p.Price),
                IsActive = true
            };
            _receiptDAL.AddReceipt(receipt);

           

            if (receipt == null)
            {
                throw new Exception("Receipt not found after saving.");
            }

            foreach (var product in products)
            {
                Stock stock = Stocks.FirstOrDefault(p => p.ProductId == product.Product.ProductId);
                ReceiptProducts receiptProducts = new ReceiptProducts
                {
                    ReceiptId = _receiptDAL.GetReceiptIdByIssueDate(receipt.IssueDate),
                    ProductId = product.Product.ProductId,
                    Quantity = 1,
                    Unit = stock.Unit,
                    SubtotalPrice = stock.SellingPrice
                };
              //  _receiptProducts.AddReceiptProduct(receiptProducts);
            }


        }
    }
}
