using kolokwiumEF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumsDBService _albumsDBService;
        public AlbumController(IAlbumsDBService albumsDBService)
        {
            _albumsDBService = albumsDBService;
        }
        /*
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAlbum(int idAlbum)
        {
            try
            {
                if(idAlbum > 0)
                {
                    return Ok(await _albumsDBService.GetAlbum(idAlbum));
                }
            }
            catch (System.Exception)
            {
                return Conflict();
            }

        }
        */
    }
}
