using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Directions.Response;
using Hackathon.Domain.ViewModels;

namespace Hackathon.Application.Services
{
    public interface IRouteService
    {
        Task<DirectionResponseViewModel> GetDirection(LatLng start, LatLng end);
    }
}
