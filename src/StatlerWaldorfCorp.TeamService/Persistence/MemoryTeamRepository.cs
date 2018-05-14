using System;
using System.Collections.Generic;
using StatlerWaldorfCorp.TeamService.Models;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public class MemoryTeamRepository : ITeamRepository
    {
        private ICollection<Team> teams;

        public MemoryTeamRepository()
        {
            if(teams == null)
                teams = new List<Team>();
            teams.Add(new Team
            {
                Id = Guid.NewGuid(),
                Name = "one"
            });
            
            teams.Add(new Team
            {
                Id = Guid.NewGuid(),
                Name = "two"
            });
        }

        public MemoryTeamRepository(ICollection<Team> teams)
        {
            this.teams = teams;
        }

        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }
    }
}