using System;
using System.Collections.Generic;
using StatlerWaldorfCorp.TeamService.Models;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public interface ITeamRepository
    {
        Team Get(Guid id);
        IEnumerable<Team> GetTeams();
        void AddTeam(Team team);
    }
}