using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hart.Controllers
{
    public class InquireNowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}