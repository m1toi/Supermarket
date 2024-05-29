using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.Entities;
using Supermarket.ViewModels.Commands;
using Supermarket.Views;

namespace Supermarket.ViewModels
{
    public class EditCategoryViewModel : BaseViewModel
    {
        private readonly CategoryBLL _categoryBLL = new CategoryBLL();
        private bool _isEditMode;
        public Category EditingCategory { get; set; }
        public string Name { get; set; } = "";

        public ICommand SaveCategoryCommand { get; set; }

        public EditCategoryViewModel()
        {
            SaveCategoryCommand = new RelayCommand<object>(SaveCategory);
            _isEditMode = false;
        }
        public EditCategoryViewModel(Category category) : this()
        {
            Name = category.Name;
            _isEditMode = true;
            EditingCategory = category;
        }

        public void SaveCategory(object? obj)
        {
            if(_categoryBLL.CategoryExists(Name, _isEditMode ? EditingCategory.CategoryId : 0))
            {
                MessageBox.Show("A category with the same name already exists.");
                return;
            }

            if (_isEditMode && EditingCategory != null)
            {
                EditingCategory.Name = Name;
                _categoryBLL.ModifyCategory(EditingCategory);
                MessageBox.Show("Category updated successfully");
            }
            else
            {
                Category newCategory = new Category()
                {
                    Name = Name
                };
                _categoryBLL.AddCategory(newCategory);
                MessageBox.Show("Category added successfully");
            }
            var currentPage = obj as Page;
            currentPage?.NavigationService?.Navigate(new AdminPage());
        }
    }
}
