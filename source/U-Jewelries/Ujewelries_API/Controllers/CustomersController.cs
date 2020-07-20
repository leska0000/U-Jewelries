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
    public class CustomersController : ApiController
    {

        // POST api/<controller>
        [Route("api/customers")]
        [HttpPost]
        public string Post(LoginDto data)
        {
                return UjewelriesService.ChackPasswordCustomer(Int32.Parse(data.id), data.password);
        }


        // PUT api/<controller>
        [Route("api/customers")]
        [HttpPut]
        public bool Registration(RegistrationDto data)
        {
            return UjewelriesService.CreateCustomer(Int32.Parse(data.id), data.name, data.password);
        }

    }
}