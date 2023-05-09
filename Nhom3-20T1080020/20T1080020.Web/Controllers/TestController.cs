using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20T1080020.Web.Controllers
{
    [RoutePrefix("thu-nghiem")]
    public class TestController : Controller
    {
        [Route("xin-chao/{name?}")]
        // GET: Test
        public string SayHello(string name , int age)
        {
            return $"Hello {name}.{age} years old ";
        }
    }
}