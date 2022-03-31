using MVC.Data;
using System;
using System.Collections.Generic;

namespace MVC.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);

        void InsertCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int id);

    }
}
