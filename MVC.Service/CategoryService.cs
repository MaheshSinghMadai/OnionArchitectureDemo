using MVC.Data;
using MVC.Repo;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.Service
{
    public class CategoryService : ICategoryService
    {
        //create an instance of the CategoryService
        private IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void InsertCategory(Category category)
        {
            _categoryRepository.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void DeleteCategory(int id)
        {
            Category c = new Category();

            //Get particular category by Id
            _categoryRepository.GetById(id);

            ///delete and save changes
            _categoryRepository.Remove(c);
            _categoryRepository.SaveChanges();
        }

       
    }
}
