using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using U_Jewelries_ClassLibrary.EF;
using U_Jewelries_ClassLibrary.Servecses;
using U_Jewelries_ClassLibrary.DTO;

namespace Ujewelries_API.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/<controller>

        [Route("api/Product")]
        [HttpPut]
        public ProductDTO GetProduct(ProductDTO data)
        {
            return UjewelriesService.GetProductByID(data);

        }

        // GET api/<controller>/
        [Route("api/Product")]
        [HttpGet]
        public List<ProductDTO> GetArr()
        {
            return UjewelriesService.AllProductsDTO();
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

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}