using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WebApplication.Net.FirstMVC.Controllers
{
    [Area("FirstMVC")]
    public class HeavyController : Controller
    {
        //
        // GET: /FirstMVC/Heavy/SomeHeavyMethod
        public async Task<IActionResult> SomeHeavyMethod()
        {
            await Task.Delay(20000);
            return View("SomeHeavyMethod");
        }
    }
}