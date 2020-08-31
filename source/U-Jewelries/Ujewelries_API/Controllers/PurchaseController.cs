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
    public class PurchaseController : ApiController
    {
        [Route("api/purchase")]
        [HttpGet]
        public List<PurchaseDTO> Get(LoginDto id)
        {
            return UjewelriesService.GetHistoryById(id.id);
        }
    }
}