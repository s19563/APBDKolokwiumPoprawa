using System.Threading.Tasks;
using kolokwiumEF.Models.DTOs;

namespace kolokwiumEF.Services
{
    public interface IDBService
    {
        Task<TeamDto?> GetTeam(int idTeam);
    }
}
