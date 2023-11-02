using GalaxyQuest.Models;
using GalaxyQuest.Services;

namespace GalaxyQuest.Interfaces
{
    public interface IMilkyWayGalaxy
    {
        Task<List<MilkyWayGalaxy>> PlanetsIndex();
    }
}
