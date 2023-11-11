using Google.Maps;
using Google.Maps.Direction;
using Google.Maps.DistanceMatrix;
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

        private readonly IMatrixService _matrixService;

        public RouteController(IRouteService routeService, IMatrixService matrixService)
        {
            _routeService = routeService;
            _matrixService = matrixService;
        }

        [HttpGet("get")]
        public async Task<DirectionResponse> GetDirection([FromQuery] decimal strLat, [FromQuery] decimal strLng, [FromQuery] decimal endLat, [FromQuery] decimal endLng)
        {
            return await _routeService.GetDirection(new LatLng(strLat, strLng), new LatLng(endLat, endLng));
        }

        [HttpGet("getMatrix")]
        public async Task<DistanceMatrixResponse> GetMatrix([FromQuery] decimal strLat, [FromQuery] decimal strLng, [FromQuery] decimal endLat, [FromQuery] decimal endLng)
        {
            return await _matrixService.GetMatrix(new LatLng(strLat, strLng), new LatLng(endLat, endLng));
        }
    }
}
