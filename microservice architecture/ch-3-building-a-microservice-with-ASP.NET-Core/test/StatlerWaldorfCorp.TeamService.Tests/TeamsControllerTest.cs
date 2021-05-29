using Xunit;
using StatlerWaldorfCorp.TeamService.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace StatlerWaldorfCorp.TeamService
{
    public class TeamsControllerTest
    {       
        [Fact]
        public void QueryTeamListReturnsCorrectTeams()
        {
            TeamsController controller = new TeamsController(new TestMemoryTeamRepository());
            var teams = (IList<Team>)(controller.GetAllTeams() as ObjectResult).Value;           
            Assert.Equal(teams.Count, 2);
            Assert.Equal(teams[0].Name, "one");
            Assert.Equal(teams[1].Name, "two");   
        }

        [Fact]
        public void CreateTeamAddsTeamToList()
        {
            TeamsController controller = new TeamsController(new TestMemoryTeamRepository());
            var teams = (IEnumerable<Team>)(controller.GetAllTeams() as ObjectResult).Value;            
            List<Team> original = new List<Team>(teams);
            Team t = new Team("sample");
            var result = controller.CreateTeam(t);
            var newTeamsRaw =(IList<Team>)(controller.GetAllTeams() as ObjectResult).Value;         

            List<Team> newTeams = new List<Team>(newTeamsRaw);
            Assert.Equal(newTeams.Count, original.Count+1);
            var sampleTeam = newTeams.FirstOrDefault(
            target => target.Name == "sample");
            Assert.NotNull(sampleTeam);
        }

    }
}