
using GoogleApi;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using Hackathon.Application.Services;
using Hackathon.Domain.ViewModels;

namespace Hackathon.Infrastructure.Services
{
    public class RouteService : IRouteService
    {
        public RouteService()
        {
            //will add point repo here.
        }

        public async Task<DirectionResponseViewModel> GetDirection(LatLng start, LatLng end)
        {
            var request = new DirectionsRequest();

            request.Key = "AIzaSyBP70Yds30-0rELR1lplMl1Pv3IR8Zut6g";
            //for adding new "posible points"
            //request.AddWaypoint(new LatLng());
            request.TravelMode = TravelMode.Walking;
            request.Origin = new LocationEx(new CoordinateEx(start.Latitude, start.Longitude));
            request.Destination = new LocationEx(new CoordinateEx(end.Latitude, end.Longitude));

            var resp = await GoogleMaps.Directions.QueryAsync(request);


            var result = new DirectionResponseViewModel();
            result.RawJson = resp.RawJson;
            result.Request = request;
            result.Routes = resp.Routes;
            //result.Status = resp.Status;
            //result.ErrorMessage = resp.ErrorMessage;
            //result.Waypoints = resp.Waypoints;
            ////result.geocoded_waypoints = resp.Waypoints;
            //result.Routes = resp.Routes;
            //result.Request = request;

            return result;
        }
    }
}
