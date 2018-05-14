using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using StatlerWaldorfCorp.TeamService.Models;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace StatlerWaldorfCorp.TeamService.Controllers
{
    public class TeamsController:Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
           
            return Ok(_teamRepository.GetTeams());
            
        }

        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {
            _teamRepository.AddTeam(team);

            return this.Created($"/teams/{team.Id}", team);
        }
    }
}