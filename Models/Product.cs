using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Product
    {
        /// <summary>
        /// ProductId
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Must have two decimal places")]
        [Range(0.0001, 1)]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

    }
}
