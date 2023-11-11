using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Directions.Response;
using Hackathon.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        private readonly IMatrixService _matrixService;

        public RouteController(IRouteService routeService, IMatrixService matrixService)
        {
            _routeService = routeService;
            _matrixService = matrixService;
        }

        [HttpGet("get")]
        public async Task<string> GetDirection([FromQuery] double strLat, [FromQuery] double strLng, [FromQuery] double endLat, [FromQuery] double endLng)
        {
            Response.Headers.Append("Access-Control-Allow-Origin", "*");
            var resp = await _routeService.GetDirection(
                new LatLng() { Latitude = strLat, Longitude = strLng },
                new LatLng() { Latitude = endLat, Longitude = endLng });
            //return resp;
            var json = JsonConvert.SerializeObject(resp);
            return json;
        }

        //[HttpGet("getMatrix")]
        //public async Task<DistanceMatrixResponse> GetMatrix([FromQuery] decimal strLat, [FromQuery] decimal strLng, [FromQuery] decimal endLat, [FromQuery] decimal endLng)
        //{
        //    return await _matrixService.GetMatrix(new LatLng(strLat, strLng), new LatLng(endLat, endLng));
        //}
    }
}
