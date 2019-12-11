using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        // GET api/values
        [HttpGet("[action]")]
        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> listOfCustomer = new List<Customer>();
            string allText = System.IO.File.ReadAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json");
            JObject rss = JObject.Parse(allText);
            object jsonObject = JsonConvert.DeserializeObject(allText);
            var postTitles =
                    from p in rss["customers"]
                    select new { id=(string)p["id"],
                        name=(string)p["name"]
                        };
            foreach (var cust in postTitles)
            {
                listOfCustomer.Add(new Customer()
                {
                    CustomerId = System.Convert.ToInt32(cust.id),
                    name = cust.name.ToString()


                });

            }

                return listOfCustomer;

        
    }
        // GET api/values
        [HttpGet("[action]")]
        public IEnumerable<Customer> GetCustomerByid(string Custid)
        {
            List<Customer> listOfCustomer = new List<Customer>();
            string allText = System.IO.File.ReadAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json");
            JObject rss = JObject.Parse(allText);
            object jsonObject = JsonConvert.DeserializeObject(allText);
            var postTitles =
                    from p in rss["customers"]
                    where (string)p["id"]== Custid
                    select new
                    {
                        id = (string)p["id"],
                        name = (string)p["name"]
                    };
            foreach (var cust in postTitles)
            {
                listOfCustomer.Add(new Customer()
                {
                    CustomerId = System.Convert.ToInt32(cust.id),
                    name = cust.name.ToString()


                });

            }

            return listOfCustomer;


        }
        // GET api/values
        [HttpGet("[action]")]
        public IEnumerable<Product> GetProducts()
        {
            List<Product> listOfProduct = new List<Product>();
            string allText = System.IO.File.ReadAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json");
            JObject rss = JObject.Parse(allText);
            object jsonObject = JsonConvert.DeserializeObject(allText);
            var postTitles =
                    from p in rss["products"]
                  
                    select new
                    {
                        id = (string)p["id"],
                        description = (string)p["description"],
                        price=System.Convert.ToDecimal(p["price"])
                    };
            foreach (var prod in postTitles)
            {
                listOfProduct.Add(new Product()
                {
                   ProductId = System.Convert.ToInt32(prod.id),
                   Description = prod.description.ToString(),
                    Price = System.Convert.ToDecimal(prod.price)


                });

            }

            return listOfProduct;


        }
        // GET api/values
        [HttpGet("[action]")]
        public IEnumerable<Product> GetProductByid(string id)
        {
            List<Product> listOfProduct = new List<Product>();
            string allText = System.IO.File.ReadAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json");
            JObject rss = JObject.Parse(allText);
            object jsonObject = JsonConvert.DeserializeObject(allText);
            var postTitles =
                    from p in rss["products"]
                    where (string)p["id"]==id
                    select new
                    {
                        id = (string)p["id"],
                        description = (string)p["description"],
                        price = System.Convert.ToDecimal(p["price"])
                    };
            foreach (var prod in postTitles)
            {
                listOfProduct.Add(new Product()
                {
                    ProductId = System.Convert.ToInt32(prod.id),
                    Description = prod.description.ToString(),
                    Price = System.Convert.ToDecimal(prod.price)


                });

            }

            return listOfProduct;


        }
        // GET api/values
        [HttpGet("[action]")]
        public IEnumerable<order> GetOrders(string id)
        {
            List<order> listOforder = new List<order>();
            string allText = System.IO.File.ReadAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json");
            JObject rss = JObject.Parse(allText);
            object jsonObject = JsonConvert.DeserializeObject(allText);
            var postTitles =
                    from p in rss["orders"]
                     select new
                    {
                         id = (string)p["id"],
                         customerId = (string)p["customerId"],
                        
                    };
            foreach (var ord in postTitles)
            {
                listOforder.Add(new order()
                {
                    Orderid= System.Convert.ToInt32(ord.id),
                    Customerid = System.Convert.ToInt32(ord.customerId)



                });

            }

            return listOforder;


        }
        // GET api/values
        [HttpGet("[action]")]
        public void SaveProduct(int id,string description,decimal price)
        {
            var newproduct = "{ 'id': " + id + ",'description': '" + description + "','price':"+price+"}";
            try
            {
                var json = System.IO.File.ReadAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json");
                var jsonObj = JObject.Parse(json);
                var experienceArrary = jsonObj.GetValue("products") as JArray;
                var newCompany = JObject.Parse(newproduct);
                experienceArrary.Add(newCompany);

                jsonObj["products"] = experienceArrary;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                       Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json", newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }


        }
        // GET api/values
        [HttpGet("[action]")]
        public void SaveCustomer(int id, string name)
        {
            var newpCustomer = "{ 'id': " + id + ",'name': '" + name + "}";
            try
            {
                var json = System.IO.File.ReadAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json");
                var jsonObj = JObject.Parse(json);
                var experienceArrary = jsonObj.GetValue("products") as JArray;
                var newCompany = JObject.Parse(newpCustomer);
                experienceArrary.Add(newCompany);

                jsonObj["customers"] = experienceArrary;
                string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj,
                                       Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(@"C:\Interview\interview-dotnet-master\interview-dotnet-master\GroceryStoreAPI\database.json", newJsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }


        }
    }
}
