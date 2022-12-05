using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    [Authorize]
    public class BoolfixController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
