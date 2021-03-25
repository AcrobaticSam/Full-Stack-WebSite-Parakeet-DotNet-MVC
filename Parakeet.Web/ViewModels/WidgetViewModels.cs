using Parakeet.Web.Models;
using Prakeet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parakeet.Web.ViewModels
{
    public class ProductsWidgetViewModel
    {
        public List<Product> Products { get; set; }

        public bool IsLatestProducts { get; set; }
    }

    public class UserNameModel
    {
        public ApplicationUser User { get; set; }
    }
}