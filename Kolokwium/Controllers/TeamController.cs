using Kolokwium.DTOs.Requests;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly LeagueDbContext leagueContext;

        public TeamController(LeagueDbContext context)
        {
            leagueContext = context;
        }

        [HttpPost("{IdTeam}/players")]
        public IActionResult EnrollPlayer(int IdTeam, PlayerDTO playerDTO)
        {
            Team team = leagueContext.Teams.Find(IdTeam);

            if (team == null)
            {
                return BadRequest("No team found!");
            }

            Player player = leagueContext.Players
                .Where(p => p.FirstName.Equals(playerDTO.FirstName))
                .Where(p => p.LastName.Equals(playerDTO.LastName))
                .Where(p => p.DateOfBirth.Equals(playerDTO.DateOfBirth)).First();

            if (player == null)
            {
                return BadRequest("No player found!");
            }

            var _link = leagueContext.PlayerTeams.Where(pt => pt.Player.Equals(player)).First();

            if (_link != null)
            {
                return BadRequest("Player unavailable!");
            }

            PlayerTeam PlayerTeam = new PlayerTeam();
            PlayerTeam.Player = player;
            PlayerTeam.Team = team;

            leagueContext.PlayerTeams.Add(PlayerTeam);
            leagueContext.SaveChanges();
            return Ok(playerDTO);
        }
    }
}
}
