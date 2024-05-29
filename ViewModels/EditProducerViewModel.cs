using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.Entities;
using Supermarket.ViewModels.Commands;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    public class EditProducerViewModel : BaseViewModel
    {
        private readonly ProducerBLL _producerBLL = new ProducerBLL();
        private bool _isEditMode;
        public Producer EditingProducer { get; set; }

        public string Name { get; set; } = "";
        public string OriginCountry { get; set; } = "";
        public ICommand SaveProducerCommand { get; set; }
        public EditProducerViewModel()
        {
            _isEditMode = false;
            SaveProducerCommand = new RelayCommand<object>(SaveProducer);
        }
        public EditProducerViewModel(Producer producer) : this()
        {
            Name = producer.Name;
            OriginCountry = producer.OriginCountry;
            _isEditMode = true;
            EditingProducer = producer;
        }
        public void SaveProducer(object? obj)
        {
            if (_producerBLL.ProducerExists(Name, _isEditMode ? EditingProducer.ProducerId : 0))
            {
                System.Windows.MessageBox.Show("A producer with the same name already exists.");
                return;
            }
            if (_isEditMode && EditingProducer != null)
            {
                EditingProducer.Name = Name;
                EditingProducer.OriginCountry = OriginCountry;
                _producerBLL.EditProducer(EditingProducer);
                System.Windows.MessageBox.Show("Producer updated successfully");
            }
            else
            {
                Producer newProducer = new Producer()
                {
                    Name = Name,
                    OriginCountry = OriginCountry
                };
                _producerBLL.AddProducer(newProducer);
                System.Windows.MessageBox.Show("Producer added successfully");
            }
            var currentPage = obj as System.Windows.Controls.Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }

    }
}
