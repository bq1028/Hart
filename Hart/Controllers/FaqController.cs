using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hart.Controllers
{
    public class FaqController : Controller
    {
        // GET: Faq
        public ActionResult Index()
        {
            return View();
        }       
    }
}