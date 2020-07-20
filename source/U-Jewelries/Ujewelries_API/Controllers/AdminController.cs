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
    public class AdminController : ApiController
    {
        // GET api/<controller> 
        [Route("api/admin")]
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        // PUT api/<controller>
        [Route("api/admin")]
        [HttpPut]
            public bool AdminRegistration(AdminRegisterationDTO data)
            {
                return UjewelriesService.CreateCustomer(Int32.Parse(data.id),
                                                    data.name, data.password,
                                                    bool.Parse(data.Admin));
            }

        // POST api/<controller>
        [Route("api/admin")]
        [HttpPost]
        public bool AddProduct()
        {
            return true;
        }

        // GET api/<controller>
        [Route("api/admin/mua")]
        [HttpGet]
        public bool MakeUserAdmin(LoginDto data)
        {
            /*
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\leska\Documents\123\ERORRLIST.txt", true))
            {
                file.WriteLine(data.id);
                file.WriteLine(data.password);
            }
                */
                return UjewelriesService.UCTM(data);

        }

        // GET api/<controller>
        [Route("api/admin/mua")]
        [HttpPut]
        public bool UpdateAccount(ProductDTO data)
        {
            return UjewelriesService.UpdateProduct(data);
        }
        
    }
}