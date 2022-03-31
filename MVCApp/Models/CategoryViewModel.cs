using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Models
{
    public class CategoryViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Display Order must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
