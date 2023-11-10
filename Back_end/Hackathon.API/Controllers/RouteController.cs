using Google.Maps;
using Google.Maps.Direction;
using Hackathon.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("get")]
        public async Task<DirectionResponse> GetDirection([FromQuery] decimal strLat, [FromQuery] decimal strLng, [FromQuery] decimal endLat, [FromQuery] decimal endLng)
        {
            return await _routeService.GetDirection(new LatLng(strLat, strLng), new LatLng(endLat, endLng));
        }
    }
}
