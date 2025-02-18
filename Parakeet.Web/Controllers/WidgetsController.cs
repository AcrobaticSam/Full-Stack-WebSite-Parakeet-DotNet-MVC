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
    public class WidgetsController : Controller
    {
        // GET: Widgets
        public ActionResult Products(bool isLatestProducts, int? CategoryID = 0)
        {
            ProductsWidgetViewModel model = new ProductsWidgetViewModel();
            model.IsLatestProducts = isLatestProducts;

            if (isLatestProducts)
            {
                model.Products = ProductsService.Instance.GetProducts(1, 8);
            }
            else if (CategoryID.HasValue && CategoryID.Value > 0)
            {
                model.Products = ProductsService.Instance.GetProductsByCategory(CategoryID.Value, 4);
            }
            else
            {
                model.Products = ProductsService.Instance.GetProducts(1, 8);
            }

            return PartialView(model);
        }
    }
}