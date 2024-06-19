using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;
using ViewModels;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;

        public PizzaController()
        {
            _pizzaService = new PizzaService();
        }

        public IActionResult Index()
        {
            var items = _pizzaService.GetAll();
            return View(items);
        }

        public IActionResult Details(int id)
        {
            var item = _pizzaService.GetDetails(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult SearchByName([FromForm] FilterViewModel filterModel)
        {
            var items = _pizzaService.SearchByName(filterModel.Name);
            return View("Index", items);
        }

        public IActionResult Create()
        {
            var pizza = new PizzaViewModel();
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Create([FromForm] PizzaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _pizzaService.Create(model);


            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var pizza = _pizzaService.GetDetails(id);
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] PizzaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _pizzaService.Update(model);


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _pizzaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
