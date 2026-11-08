using DentalisApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DentalisApp.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DentalisApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController()
        {
           
        }

       [AllowAnonymous]
        public IActionResult Index()
        {
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
