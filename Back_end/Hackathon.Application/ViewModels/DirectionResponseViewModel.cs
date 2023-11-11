//using Google.Maps.Direction;
//using Newtonsoft.Json;

using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using Newtonsoft.Json;

namespace Hackathon.Domain.ViewModels
{
    public class DirectionResponseViewModel : DirectionsResponse
    {
        [JsonProperty("request")]
        public DirectionsRequest Request { get; set; }

        //[JsonProperty("geocoded_waypoints")]
        //public GeocodedWaypoint[] geocoded_waypoints { get; set; }
    }
}
