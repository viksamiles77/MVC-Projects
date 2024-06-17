using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaservice;

        public PizzaController()
        {
            _pizzaservice = new PizzaService();
        }
        public IActionResult Index()
        {
            var items = _pizzaservice.GetAll();
            return View(items);
        }

        public IActionResult Details(int id)
        {
            var item = _pizzaservice.GetDetails(id);
            return View(item);
        }

        public IActionResult SearchByName(string name)
        {
            return View();
        }
    }
}
