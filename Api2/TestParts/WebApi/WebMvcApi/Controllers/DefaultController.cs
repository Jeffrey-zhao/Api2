using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMvcApi.Customs;

namespace WebMvcApi.Controllers
{
    [BasicAuthentication]
    public class DefaultController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "default value1", "default value2" };
        }
    }
}
