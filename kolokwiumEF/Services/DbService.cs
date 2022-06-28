using kolokwiumEF.Models;
using kolokwiumEF.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace kolokwiumEF.Services
{
    public class DbService : IDBService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TeamDto?> GetTeam(int idTeam)
        {
            return await _dbContext.Team.Select(t => new TeamDto()
            {
                TeamName = t.TeamName,
                TeamDescription = t.TeamDescription,
                Organization = t.Organization,
                Memberships = t.Memberships.Select(m => m)
                    .Where(m => m.TeamID == t.TeamID)
                    .OrderBy(m => m.MembershipDate)
                    .ToList()
            })
            .Where(a => a.TeamID == idTeam)
            .SingleOrDefaultAsync();
        }
    }
}
