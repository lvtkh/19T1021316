using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19T1021316.Web.Controllers
{
    //[RoutePrefix("thu-nghiem")]
    public class textController : Controller
    {
        // GET: text
        //[Route("chao-hoi/{name?}/{age?}")]
        //public string SayHello(int age = 18, string name = "" )
        //{
        //return $"Hello {name}.{age} years old";
        //}
        public string SayHello(string id) 
        {
            return $"id={id}";
        }
    }
}