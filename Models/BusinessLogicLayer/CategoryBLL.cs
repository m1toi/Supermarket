using System.Collections.ObjectModel;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.Entities;

namespace Supermarket.Models.BusinessLogicLayer
{
    public class CategoryBLL
    {
        private readonly CategoryDAL _categoryDAL;

        public CategoryBLL()
        {
            _categoryDAL = new CategoryDAL();
        }

        public ObservableCollection<Category> GetCategories()
        {
            ObservableCollection<Category> categories = new ObservableCollection<Category>();
            foreach (var category in _categoryDAL.GetCategories())
            {
                categories.Add(category);
            }
            return categories;
        }
        public void AddCategory(Category category)
        {
            _categoryDAL.AddCategory(category);
        }

        public void ModifyCategory(Category category)
        {
            _categoryDAL.ModifyCategory(category);
        }
        
        public void DeleteCategory(Category category)
        {
            _categoryDAL.DeleteCategory(category);
        }

        public bool CategoryExists(string name, int categoryId = 0)
        {
            var categories = GetCategories();
            return categories.Any(category => category.Name == name && category.CategoryId != categoryId);
        }
    }
}
