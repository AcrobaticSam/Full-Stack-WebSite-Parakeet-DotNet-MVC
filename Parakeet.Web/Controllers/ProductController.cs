﻿using Parakeet.Services;
using Parakeet.Web.ViewModels;
using Prakeet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Parakeet.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search, int? pageNo)
        {
            var pageSize = ConfigurationsService.Instance.PageSize();

            ProductSearchViewModel model = new ProductSearchViewModel();
            model.SearchTerm = search;

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            var totalRecords = ProductsService.Instance.GetProductsCount(search);
            model.Products = ProductsService.Instance.GetProducts(search, pageNo.Value, pageSize);

            model.Pager = new Pager(totalRecords, pageNo, pageSize);

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            NewProductViewModel model = new NewProductViewModel();

            model.AvailableCategories = CategoriesService.Instance.GetAllCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewProductViewModel model)
        {
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Ingredients = model.Ingredients;
            newProduct.Analysis = model.Analysis;
            newProduct.Info = model.Info;
            newProduct.Intro = model.Intro;
            newProduct.Price = model.Price;
            newProduct.Category = CategoriesService.Instance.GetCategory(model.CategoryID);
            newProduct.ImageURL = model.ImageURL;
            newProduct.ImageURL2 = model.ImageURL2;
            newProduct.ImageURL3 = model.ImageURL3;
            newProduct.ImageURL4 = model.ImageURL4;

            ProductsService.Instance.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProductViewModel model = new EditProductViewModel();

            var product = ProductsService.Instance.GetProduct(ID);

            model.ID = product.ID;
            model.Name = product.Name;
            model.Description = product.Description;
            model.Ingredients = product.Ingredients;
            model.Analysis = product.Analysis;
            model.Info = product.Info;
            model.Intro = product.Intro;
            model.Price = product.Price;
            model.CategoryID = product.Category != null ? product.Category.ID : 0;
            model.ImageURL = product.ImageURL;
            model.ImageURL2 = product.ImageURL2;
            model.ImageURL3 = product.ImageURL3;
            model.ImageURL4 = product.ImageURL4;

            model.AvailableCategories = CategoriesService.Instance.GetAllCategories();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var existingProduct = ProductsService.Instance.GetProduct(model.ID);
            existingProduct.Name = model.Name;
            existingProduct.Description = model.Description;
            existingProduct.Ingredients = model.Ingredients;
            existingProduct.Analysis = model.Analysis;
            existingProduct.Info = model.Info;
            existingProduct.Intro = model.Intro;
            existingProduct.Price = model.Price;

            existingProduct.Category = null; //mark it null. Because the referncy key is changed below
            existingProduct.CategoryID = model.CategoryID;

            //dont update imageURL if its empty
            if (!string.IsNullOrEmpty(model.ImageURL))
            {
                existingProduct.ImageURL = model.ImageURL;
            }
            if (!string.IsNullOrEmpty(model.ImageURL2))
            {
                existingProduct.ImageURL2 = model.ImageURL2;
            }

            if (!string.IsNullOrEmpty(model.ImageURL3))
            {
                existingProduct.ImageURL3 = model.ImageURL3;
            }

            if (!string.IsNullOrEmpty(model.ImageURL4))
            {
                existingProduct.ImageURL4 = model.ImageURL4;
            }


            ProductsService.Instance.UpdateProduct(existingProduct);

            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsService.Instance.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            ProductViewModel model = new ProductViewModel();

            model.Product = ProductsService.Instance.GetProduct(ID);

            if (model.Product == null) return HttpNotFound();

            return View(model);
        }
    }
}