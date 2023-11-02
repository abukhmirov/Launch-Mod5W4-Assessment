using GalaxyQuest.Interfaces;
using GalaxyQuest.Models;
using GalaxyQuest.Services;
using Microsoft.AspNetCore.Mvc;

namespace GalaxyQuest.Controllers
{

    public class PlanetsController : Controller
    {

        private readonly IMilkyWayGalaxy _milkyWayGalaxy;

        public PlanetsController(IMilkyWayGalaxy milkyWayGalaxy)
        {

            _milkyWayGalaxy = milkyWayGalaxy;
        }


        public async Task<IActionResult> IndexAsync()
        {
            var milkyWayPlanets = MilkyWayGalaxy.Planets;

            List<MilkyWayGalaxy> SWplanets = await _milkyWayGalaxy.PlanetsIndex();
            ViewBag.SWPlanets = SWplanets;

            return View(milkyWayPlanets);
        }

    }
}
