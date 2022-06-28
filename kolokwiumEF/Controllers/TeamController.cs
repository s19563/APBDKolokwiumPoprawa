using kolokwiumEF.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace kolokwiumEF.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IDBService _dbService;
        public TeamController(IDBService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{idTeam}")]
        public async Task<IActionResult> GetTeam(int idTeam)
        {
            try
            {
                var team = await _dbService.GetTeam(idTeam);
                if (team == null) return NotFound("Team not found!");
                return Ok(team);
            }
            catch (System.Exception)
            {
                return Conflict();
            }
        }
    }
}