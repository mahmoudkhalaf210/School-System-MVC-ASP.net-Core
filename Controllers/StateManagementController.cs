using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult setTempData()
        {
            TempData["msg"] = "hello";

            return Content("data saved");
        }
        public IActionResult get1()
        {
            string message = "empty message";
            
            if(TempData.ContainsKey("msg"))
            {
                message = TempData.Peek("msg").ToString();
            }
            
            return Content("get1" + message);
        }
        public IActionResult get2()
        {
            string message = TempData["msg"].ToString();
            return Content("get2" + message);
        }

        public IActionResult setSession()
        {
            HttpContext.Session.SetString("name", "abdelrahman");
            HttpContext.Session.SetInt32("age", 23);

            return Content("session saved");
        }

        public IActionResult getSession()
        {
            string? name = HttpContext.Session.GetString("name");
            int? age = HttpContext.Session.GetInt32("age");

            return Content($"Name: {name}  -  Age: {age}");
        }
    }
}
