using Microsoft.AspNetCore.Mvc;
using UserLogin_Project.Models;

namespace UserLogin_Project.Controllers
{
    public class UsbmController : Controller
    {
        private readonly MyProjectContext context;
        public UsbmController(MyProjectContext context) 
        {
            this.context = context;
        }
        public IActionResult LoginView()
        {
            if(HttpContext.Session.GetString("ActiveId") != null)
            {
                return RedirectToAction("Welcome");
            }
           
            return View();
        }
        public IActionResult Login(UserLogin obj)
        {
            var data=context.UserLogins.Where(x=>x.MailId==obj.MailId && x.UPassword==obj.UPassword).FirstOrDefault(); ;
            if (data != null)
            {
                HttpContext.Session.SetString("ActiveId",data.MailId);
                return RedirectToAction("Welcome");
            }
            else
            {
                return BadRequest("Login Fail");
            }
        }

        public IActionResult Welcome()
        {
            if (HttpContext.Session.GetString("ActiveId") != null)
            {
                Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
                Response.Headers.Append("Pragma", "no-cache");
                Response.Headers.Append("Expires", "0");
                ViewBag.Msg = HttpContext.Session.GetString("ActiveId");
               
            }
            else
            {
                return RedirectToAction("LoginView");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString("ActiveId") != null)
            {
                HttpContext.Session.Remove("ActiveId");
                return RedirectToAction("LoginView");
            }
            return View();
        }
    }
}
