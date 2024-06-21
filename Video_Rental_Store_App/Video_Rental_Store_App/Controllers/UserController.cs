//using Microsoft.AspNetCore.Mvc;
//using ViewModels;
//using DataAccess;

//namespace Video_Rental_Store_App.Controllers
//{
//    public class UserController : Controller
//    {
//        public IActionResult Index()
//        {
//            var userList = StaticDb.Users;
//            return View();
//        }

//        public IActionResult CreateUser()
//        {
//            var createUser = new UserViewModel();
//            return View(createUser);
//        }

//        public IActionResult CreateUser(UserViewModel model)
//        {
//            model.Id = StaticDb.Users.Max(x => x.Id) + 1;
//            StaticDb.Users.Add(model);
//            return RedirectToAction("Index");
//        }
//    }
//}
