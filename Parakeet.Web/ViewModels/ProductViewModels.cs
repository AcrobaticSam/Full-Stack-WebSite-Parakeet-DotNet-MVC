using Prakeet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parakeet.Web.ViewModels
{
    public class ProductSearchViewModel
    {
        public List<Product> Products { get; set; }
        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }

    public class NewProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Analysis { get; set; }
        public string Info { get; set; }
        public string Intro { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public string ImageURL { get; set; }
        public string ImageURL2 { get; set; }
        public string ImageURL3 { get; set; }
        public string ImageURL4 { get; set; }

        public List<Category> AvailableCategories { get; set; }
    }

    public class EditProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Analysis { get; set; }
        public string Info { get; set; }
        public string Intro { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public string ImageURL { get; set; }
        public string ImageURL2 { get; set; }
        public string ImageURL3 { get; set; }
        public string ImageURL4 { get; set; }

        public List<Category> AvailableCategories { get; set; }
    }


    public class ProductViewModel
    {
        public Product Product { get; set; }
    }
}