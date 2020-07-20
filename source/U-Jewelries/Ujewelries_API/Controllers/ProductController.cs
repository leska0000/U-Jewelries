using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using U_Jewelries_ClassLibrary.DTO;
using U_Jewelries_ClassLibrary.Servecses;

namespace Ujewelries_API.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route("api/Product")]
        [HttpPost]
        public bool Post(ProductDTO value)
        {

            return UjewelriesService.CreateProduct(value.id, value.name,
                                                    Convert.ToDouble(value.price), Convert.ToDouble(value.cost),
                                                    Int32.Parse(value.inv), Int32.Parse(value.supplier_id),
                                                    value.category, bool.Parse(value.is_active)
                                                    );
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}