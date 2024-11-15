using Microsoft.AspNetCore.Mvc;

namespace UserLogin_Project.Controllers
{
    public class PassController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/html/Demo.html");
        }

        public IActionResult ViewBageData()
        {
            ViewBag.MyMessage = "Hi Friends This is My Bag";
            var x = ViewBag.MyMessage2 = "Welcome to USBM";

            ViewBag.Mix = x;
            ViewData["Vijay"] = "My Name is vijay";

            return View();
        }

        

        public ActionResult FirstAction()
        {
            TempData["Message"] = "Hello from TempData!";
            return RedirectToAction("SecondAction");
        }

        public ActionResult SecondAction()
        {
            var message = TempData["Message"]; // "Hello from TempData!"

            
            return View();
        }


    }
}
