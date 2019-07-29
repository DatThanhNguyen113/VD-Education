using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VDSoLienLac.Hubs;

namespace VDSoLienLac.Controllers
{
    public class HubController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetConnectionManager()
        {
            try
            {
                var mresult = JsonConvert.SerializeObject(NotifyHub.connectionManager);
                return Ok(new { data = mresult, status = 200 });
            }
            catch (Exception ex)
            {
                return Ok(new { data = ex.Message, status = 400 });
            }
        }
    }
}
