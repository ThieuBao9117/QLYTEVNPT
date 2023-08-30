using App.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Areas.AdminCP.Controllers
{
    [Area("AdminCP")]
   
    public class AdminCP : Controller
    {
        [Route("/admincp/")]
        public IActionResult Index()  => View();
    }
}