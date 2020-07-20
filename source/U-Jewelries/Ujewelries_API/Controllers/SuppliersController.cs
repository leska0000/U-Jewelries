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
    public class SuppliersController : ApiController
    {
        // GET api/<controller>
        [Route("api/suppliers")]
        [HttpGet]
        
        public List<SupplierDTO> Get()
       {
            return UjewelriesService.GetSuppliersList();
       }
       
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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