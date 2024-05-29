using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.Entities;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class ProducerBLL
    {
        private readonly ProducerDAL _producerDAL = new ProducerDAL();

        public ProducerBLL()
        {
            _producerDAL = new ProducerDAL();
        }
        public ObservableCollection<Producer> GetProducers()
        {
            ObservableCollection<Producer> producers = new ObservableCollection<Producer>();
            foreach (var producer in _producerDAL.GetProducers())
            {
                producers.Add(producer);
            }
            return producers;
        }
        public void AddProducer(Producer producer)
        {
            _producerDAL.AddProducer(producer);
        }
        public void EditProducer(Producer producer)
        {
            _producerDAL.ModifyProducer(producer);
        }
        public void DeleteProducer(Producer producer)
        {
            _producerDAL.DeleteProducer(producer);
        }
        public bool ProducerExists(string name, int producerId = 0)
        {
            var producers = GetProducers();
            return producers.Any(producer => producer.Name == name && producer.ProducerId != producerId);
        }
    }
}
