using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using StatlerWaldorfCorp.TeamService.Models;
namespace StatlerWaldorfCorp.TeamService
{
    // [ApiController]
    // [Route("[controller]")]
    public class TeamsController : Controller
    {
        public TeamsController()
        {
        }
        
        [HttpGet]
        public IEnumerable<Team> GetAllTeams()
        {
            return new Team[] { new Team("one"), new Team("two") };
        }

               
    }
}