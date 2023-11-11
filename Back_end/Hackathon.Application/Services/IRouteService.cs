using Google.Maps;
using Google.Maps.Direction;

namespace Hackathon.Application.Services
{
    public interface IRouteService
    {
        Task<DirectionResponse> GetDirection(LatLng start, LatLng end);
    }
}
