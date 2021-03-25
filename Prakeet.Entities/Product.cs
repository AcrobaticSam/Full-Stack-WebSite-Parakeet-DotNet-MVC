using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakeet.Entities
{
    public class Product : BaseEntity
    {
        [Range(1, 100000)]
        public decimal Price { get; set; }

        [MaxLength(50000)]
        public string Ingredients { get; set; }

        [MaxLength(50000)]
        public string Analysis { get; set; }


        [MaxLength(50000)]
        public string Info { get; set; }


        [MaxLength(50000)]
        public string Intro { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public string ImageURL { get; set; }

        public string ImageURL2 { get; set; }

        public string ImageURL3 { get; set; }

        public string ImageURL4 { get; set; }
    }
}
