using System;
using System.Collections.Generic;
using System.Linq;
using StatlerWaldorfCorp.TeamService.Models;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> teams;
        public MemoryTeamRepository()
        {
            if (teams == null)
            {
                teams = new List<Team>();
            }
        }
        public MemoryTeamRepository(ICollection<Team> teamsParam)
        {
            teams = teamsParam;
        }
        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }

        public Team Get(Guid id) {
			return teams.FirstOrDefault(t => t.ID == id);			
		}

        public void AddTeam(Team t)
        {
            teams.Add(t);
        }
    }
}
