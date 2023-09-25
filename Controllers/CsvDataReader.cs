using Microsoft.AspNetCore.Mvc;

namespace CSV_Modifier_Client.Controllers
{
    public class CsvDataReader : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
