using Microsoft.AspNetCore.Mvc;

namespace Online_Inventory_Management_System.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
