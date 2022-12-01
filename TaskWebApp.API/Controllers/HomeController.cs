using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            var mytask = new HttpClient().GetStringAsync("https://www.google.com");

            var data = await mytask;

            return Ok(data);  
        }
    }
}
