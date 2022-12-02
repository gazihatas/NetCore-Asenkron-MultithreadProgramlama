using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("İstek başladı");

                /*
                await Task.Delay(5000, token);

                //Manuel metot ile istedği sonlandırma
                token.ThrowIfCancellationRequested();

                var mytask = new HttpClient().GetStringAsync("https://www.google.com");

                var data = await mytask;
                */

                Enumerable.Range(1, 10).ToList().ForEach(x =>
                {
                    Thread.Sleep(1000);

                    token.ThrowIfCancellationRequested();
                    ;
                });
                
                _logger.LogInformation("İstek bitti");

                //return Ok(data);
                return Ok("İşler Bitti");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("İstek iptal edildi:" + ex.Message);
                return BadRequest();
            }   
        }
    }
}
