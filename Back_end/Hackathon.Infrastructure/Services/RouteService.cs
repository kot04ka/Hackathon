using Google.Maps;
using Google.Maps.Direction;
using Hackathon.Application.Services;

namespace Hackathon.Infrastructure.Services
{
    public class RouteService : IRouteService
    {
        public RouteService()
        {
            //will add point repo here.
        }

        public async Task<DirectionResponse> GetDirection(LatLng start, LatLng end)
        {
            var request = new DirectionRequest();

            request.Mode = TravelMode.walking;
            //for adding new "posible points"
            //request.AddWaypoint(new LatLng());

            request.Origin = start;
            request.Destination = end;

            var resp = await (new DirectionService()).GetResponseAsync(request);

            return resp;
        }
    }
}
