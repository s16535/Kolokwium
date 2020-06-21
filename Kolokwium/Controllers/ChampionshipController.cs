using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Controllers
{
    [Route("api/championships")]
    [ApiController]
    public class ChampionshipController : ControllerBase
    {
        private readonly LeagueDbContext leagueContext;

        public ChampionshipController(LeagueDbContext context)
        {
            leagueContext = context;
        }

        [HttpGet("{IdChampionship}/teams")]
        public IActionResult GetTeams(int IdChampionship)
        {
            Championship championship = leagueContext.Championships.Find(IdChampionship);

            if (championship == null)
            {
                return BadRequest("No championships found!");
            }

            var teams = leagueContext.Teams.Join(leagueContext.ChampionshipTeams, team => team.IdTeam, championship => championship.IdTeam, (t, c) => new { Team = t, Championship = c } );

            var championsTeams = teams.Where(e => e.Championship.Equals(championship)).ToList();

            var res = from tmp in championsTeams orderby tmp.Championship.Score 
                      select new
                      {
                          tmp.Team.IdTeam,
                          tmp.Team.TeamName,
                          tmp.Team.MaxAge,
                          tmp.Championship.Score
                      };

            return Ok(res);
        }
    }
}
