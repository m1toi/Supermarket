using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.Entities;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class StockBLL
    {
        private readonly StockDAL _stockDAL;
        public StockBLL()
        {
            _stockDAL = new StockDAL();
        }

        public ObservableCollection<Stock> GetStocks()
        {
            ObservableCollection<Stock> stocks = new ObservableCollection<Stock>();
            foreach (var stock in _stockDAL.GetStocks())
            {
                stocks.Add(stock);
            }
            return stocks;
        }

        public void AddStock(Stock stock)
        {
            _stockDAL.AddStock(stock);
        }
        public void ModifyStock(Stock stock)
        {
            _stockDAL.ModifyStock(stock);
        }
        public void DeleteStock(Stock stock)
        {
            _stockDAL.DeleteStock(stock);
        }

    }
}
