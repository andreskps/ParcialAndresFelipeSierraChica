using Microsoft.AspNetCore.Mvc;

namespace WebPagesAPI.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        public TicketsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Validate() 
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Validate(Guid? id, string entraceGate)
        {
            try
            {

                var url = "https://localhost:7147/api/Tickets/Validate/" + id + "/" + entraceGate;
                var json = await _httpClient.CreateClient().PutAsync(url, null);
                var result = await json.Content.ReadAsStringAsync();

                TempData["Message"] = result;

            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
            }


            return RedirectToAction("Validate");

        }
    }
}
