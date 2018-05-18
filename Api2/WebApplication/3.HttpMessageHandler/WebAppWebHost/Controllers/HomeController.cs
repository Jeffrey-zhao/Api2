using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAppWebHost.Controllers
{
    public class HomeController : Controller
    {
        string result =string.Empty;
        // GET: Home
        public string Index()
        {
            return "Index";
        }
    }
}