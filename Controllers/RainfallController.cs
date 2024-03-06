using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RainFall.components.schemas;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;
using System.Security.Cryptography;
using System.Web;

namespace RainFall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {

        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <description>
        /// Retrieve the latest readings for the specified stationId
        /// </description>
        /// <param name="stationId"></param>
        /// <param name="count"></param>
        /// <returns>Json</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("id/{stationId}/readings")]
        [Route("id/{stationId}/{count}/readings")]
        [SwaggerResponse(200, "A list of rainfall readings successfully retrieved")]
        [SwaggerResponse(400, "Invalid request")]
        [SwaggerResponse(404, "No readings found for the specified stationId")]
        [SwaggerResponse(500, "Internal server error")]        
        public async Task<IActionResult> get_rainfall(string stationId, int? count)
        {
            string Response = "";
            string CurrentURL = HttpContext.Request.GetDisplayUrl();

            try
            {
                if (count == null)
                {
                    Uri myUri = new Uri(CurrentURL);
                    string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("limit");

                    if (param1 != null && param1 != "")
                    {
                        count = int.Parse(param1);
                    }
                    else
                    {
                        count = 10;
                    }

                }

                Response = await GetReadingsPerStation(stationId, count);

                if (Response != null)
                {
                    Response = Response.Replace("@id", "id");

                    rainfallReadingResponse deserializedRainFallResponse = JsonConvert.DeserializeObject<rainfallReadingResponse>(Response);

                    if (deserializedRainFallResponse.items.Count() <= 0)
                    {
                        return RedirectToAction("index", "error", new { statusCode = 404 });
                    }

                    if (deserializedRainFallResponse.items.Count() > 100)
                    {
                        return RedirectToAction("index", "error", new { statusCode = 400 });
                    }

                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return Ok(Response);
        }

        /// <summary>
        /// This method will get the API response from environment.data.gov.uk
        /// per station for rainfall reading
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="count"></param>
        /// <returns>Json</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("{stationId}/{count}")]
        public async Task<string> GetReadingsPerStation(string stationId, int? count)
        {
            string Response = "";

            using (var client = new System.Net.Http.HttpClient())
            {
                string url = $"https://environment.data.gov.uk/flood-monitoring/id/stations/" + stationId + "/readings?_sorted&_limit=" + count.ToString();
                HttpResponseMessage response = await client.GetAsync(url);
                Response = await response.Content.ReadAsStringAsync();
            }

            return Response;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public rainfallReadingResponse ParseResponseToRainFallMaster(string reponse)
        {
            rainfallReadingResponse deserializedRainFallResponse = JsonConvert.DeserializeObject<rainfallReadingResponse>(reponse);

            return deserializedRainFallResponse;

        }

        //[Microsoft.AspNetCore.Mvc.HttpPost]
        //public IActionResult? WithError(string reponse)
        //{
        //    var response = false;

        //    rainfallReadingResponse deserializedRainFallResponse = JsonConvert.DeserializeObject<rainfallReadingResponse>(reponse);

        //    if (deserializedRainFallResponse.items.Count() <= 0)
        //    {
        //        response = true;
        //        return RedirectToAction("index", "error", new { statusCode = 404 });
        //    }

        //    if (deserializedRainFallResponse.items.Count() > 100)
        //    {
        //        response = true;
        //        return RedirectToAction("index", "error", new { statusCode = 400 });
                
        //    }

        //    return null;
        //}


    }


    

}
