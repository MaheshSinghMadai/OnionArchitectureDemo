using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Service;
using MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Web.Controllers
{
    public class CategoryController : Controller
    {
        //creating an instance of the ICategory service
        //passing to the constructor
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CategoryViewModel> model = new List<CategoryViewModel>();
            _categoryService.GetAllCategories().ToList().ForEach(u =>
            {
                _categoryService.GetCategoryById(u.Id);
                CategoryViewModel cvm = new CategoryViewModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    DisplayOrder = u.DisplayOrder
                };
                model.Add(cvm);
            });
            return View(model);
        }

        //GET-Create 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST-Create 
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CategoryViewModel cvm)
        {
            Category obj = new Category
            {
                Name = cvm.Name,
                DisplayOrder = cvm.DisplayOrder
            };

            //passing Category obj into the InserUser() function
            _categoryService.InsertCategory(obj);
            if (obj.Id > 0)
            {
                return RedirectToAction("Index");
            }
            return View(cvm);
        }

        //GET-Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CategoryViewModel cvm = new CategoryViewModel();
            if(id != 0)
            {
                Category obj = _categoryService.GetCategoryById(id);
                cvm.Name = obj.Name;
                cvm.DisplayOrder = obj.DisplayOrder;
            }
            return View(cvm);
        }

        //POST-Edit
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(CategoryViewModel model)
        {
            Category cvm = _categoryService.GetCategoryById(model.Id);
            
            cvm.Name = model.Name;
            cvm.DisplayOrder = model.DisplayOrder;

            _categoryService.UpdateCategory(cvm);
            if (model.Id > 0)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //GET-Delete
        public IActionResult Delete(int id)
        {
            CategoryViewModel cvm = new CategoryViewModel();
            if (id != 0)
            {
                Category obj = _categoryService.GetCategoryById(id);
                cvm.Name = obj.Name;
                cvm.DisplayOrder = obj.DisplayOrder;
            }
            return View(cvm);
        }

        //POST-Delete
        [HttpPost]      
        public IActionResult DeletePost(int id, IFormCollection form)
        {         
            _categoryService.DeleteCategory(id);

            return RedirectToAction("Index");
        }

    }
}
