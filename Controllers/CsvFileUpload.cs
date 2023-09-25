using Microsoft.AspNetCore.Mvc;

namespace CSV_Modifier_Client.Controllers
{
    public class CsvFileUpload : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
