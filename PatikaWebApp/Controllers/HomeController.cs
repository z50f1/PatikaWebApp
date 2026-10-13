using Microsoft.AspNetCore.Mvc;
using PatikaWebApp.Models;
using PatikaWebApp.Services;

namespace PatikaWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gyogyszerek()
        {
            List<Gyogyszer> gyogyszerek = new GyogyszerService().GetAll();
            return View(gyogyszerek);
        }

        public IActionResult Gyogyszer(int id)
        {
            Gyogyszer? gyogyszer = new GyogyszerService().GetById(id);
            if (gyogyszer == null)
                return NotFound();
            return View(gyogyszer);
        }
    }
}
