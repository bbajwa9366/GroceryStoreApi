using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class Customer
    {
        /// <summary>
        /// CustomerId
        /// </summary>
        public int CustomerId { get; set; }

       
        [StringLength(20)]
        public string name { get; set; }

       
    }
}
