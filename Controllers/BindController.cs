using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    public class BindController : Controller
    {
        // Model Binding: maping action parameter with request data(formData => GET, QueryString => POST, RoutData => Conroller/Action/id)   
        // primiteive type
        public IActionResult testPrimative(int id, string name, string[] arr)
        {
            return Content($"id: {id} - Name: {name} Array: {arr[1]}");
        }
    }
}
