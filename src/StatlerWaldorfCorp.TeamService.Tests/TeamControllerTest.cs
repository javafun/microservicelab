using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StatlerWaldorfCorp.TeamService.Controllers;
using StatlerWaldorfCorp.TeamService.Models;
using StatlerWaldorfCorp.TeamService.Persistence;
using StatlerWaldorfCorp.TeamService.Tests.Helpers;
using Xunit;

namespace StatlerWaldorfCorp.TeamService.Tests
{
    public class TeamControllerTest
    {
        private TeamsController controller;

        public TeamControllerTest()
        {
            controller = new TeamsController(new MemoryTeamRepository());
        }
        [Fact,TestPriority(2)]
        public async void QueryTeamListReturnsCorrectTeams()
        {
            var teams = (IEnumerable<Team>) ((await controller.GetAllTeams() as ObjectResult).Value);
            
            Assert.Equal(teams.Count(),2);
        }

        [Fact,TestPriority(1)]
        public async void CreateTeamAddsTeamToList() 
        {
            TeamsController controller = new TeamsController(new MemoryTeamRepository());
            var teams = (IEnumerable<Team>)(await controller.GetAllTeams() as ObjectResult).Value;
            List<Team> original = new List<Team>(teams);
            
            Team t = new Team("sample");
            var result = controller.CreateTeam(t);
            //TODO: also assert that the destination URL of the new team reflects the team's GUID
            Assert.Equal((result as ObjectResult).StatusCode, 201);

            var actionResult = await controller.GetAllTeams() as ObjectResult;            
            var newTeamsRaw = (IEnumerable<Team>)( await controller.GetAllTeams() as ObjectResult).Value;
            List<Team> newTeams = new List<Team>(newTeamsRaw);
            Assert.Equal(newTeams.Count, original.Count+1);
            var sampleTeam = newTeams.FirstOrDefault( target => target.Name == "sample");
            Assert.NotNull(sampleTeam);            
        }
    }
}