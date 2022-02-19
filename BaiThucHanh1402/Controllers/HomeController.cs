using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BaiThucHanh1402.Models;


namespace BaiThucHanh1402.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        GiaiPT gpt = new GiaiPT();
        GiaiPTB2 gptb2 = new GiaiPTB2();
        public IActionResult Index()
        {
            return View();
        }

        
        public ActionResult GiaiPTBac1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiaiPTBac1(double hesoa, double hesob)
        {
            double x = gpt.GiaiPTBac1(hesoa, hesob);
            ViewBag.nghiemPT = x;
            return View();
        }

        public ActionResult GiaiPTBac2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiaiPTBac2(double hesoa, double hesob, double hesoc)
        {
            double x1,x2;
            double delta;
            delta= gptb2.GiaiPTBac2(hesoa, hesob, hesoc);
            if(delta < 0)
            { 
                ViewBag.KetLuan = "PT Vo Nghiem!";
            }
            else if(delta==0)
            {                
                ViewBag.KetLuan = "PT Co Nghiem la: ";
                x1 = x2 = -hesob/(2*hesoa);    
                ViewBag.nghiemPTx1 = x1;
                ViewBag.nghiemPTx2 = x2;           
            }
            else
            {
                ViewBag.KetLuan = "PT Co Nghiem la: ";
                delta = Math.Sqrt(delta);
                x1 = (-hesob + delta) / (2*hesoa);
                x2 = (-hesob - delta) / (2*hesoa);
                ViewBag.nghiemPTx1 = x1;
                ViewBag.nghiemPTx2 = x2;
            }
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
