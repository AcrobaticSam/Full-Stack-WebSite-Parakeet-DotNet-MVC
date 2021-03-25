using Prakeet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parakeet.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> FeaturedCategories { get; set; }
        public List<Product> FeaturedProducts { get; set; }
    }
}