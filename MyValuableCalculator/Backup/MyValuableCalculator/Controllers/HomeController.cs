using MyValuableCalculator.Models;
using MyValuableCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyValuableCalculator.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                ElementaryMath = new ElementaryMath()
            };
            return View(model);
        }

        //
        // POST: /Home/
        [HttpPost]
        public ActionResult Index(ElementaryMath elementaryMath)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    elementaryMath.Compute();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, e.Message);
                }
            }

            var model = new HomeIndexViewModel
            {
                ElementaryMath = elementaryMath
            };
           
            return View(model);
        }

    }
}
