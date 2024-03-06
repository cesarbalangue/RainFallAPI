using Microsoft.AspNetCore.Mvc;

namespace RainFall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : Controller
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            Response.Clear();
            Response.StatusCode = statusCode;

            ViewBag.ErrorCode = statusCode.ToString();

            switch (statusCode)
            {               
                case 400:
                    ViewBag.ErrorDescription = "Invalid request";
                    return View("errorResponse");
                case 404:
                    ViewBag.ErrorDescription = "No readings found for the specified stationId";
                    return View("errorResponse");
                case 500:
                    ViewBag.ErrorDescription = "Internal server error";
                    return View("errorResponse");
                default:
                    ViewBag.ErrorDescription = "Unknown Error";
                    return View("errorResponse");
            }
        }
    }
}
