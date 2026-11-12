using DentalisApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DentalisApp.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DentalisApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (IsUserAuthenticated)
            {
                RedirectToAction("Index", "Patient");
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
