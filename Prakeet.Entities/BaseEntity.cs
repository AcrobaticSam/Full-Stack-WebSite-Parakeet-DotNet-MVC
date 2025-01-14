﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prakeet.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }

        [Required]
        [MinLength(5), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50000)]
        public string Description { get; set; }
    }
}
