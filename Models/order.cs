using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class order
    {
        /// <summary>
        /// orderId
        /// </summary>
        public int Orderid { get; set; }
        /// <summary>
        /// orderId
        /// </summary>
        public int Customerid { get; set; }


        public IEnumerable<Item> Items { get; set; }
    }
}
