using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET : api/players
        [HttpGet()]
        public ActionResult<IEnumerable<Player>> GetPlayers()
        {
            return Ok(_playerService.GetPlayers());
        }


        // GET : api/players/5
        [HttpGet("{id}")]
        public ActionResult<Player> GetPlayer(int id)
        {
            var player = _playerService.GetPlayer(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }


        // POST : api/players
        [HttpPost]
        public ActionResult<Player> PostPlayer(Player player)
        {
            _playerService.AddPlayer(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }


        // PUT : api/players/5
        [HttpPut("{id}")]
        public IActionResult PutPlayer(int id, Player player)
        { 
            if (id != player.Id) 
            {
                return BadRequest();
            }
            _playerService.UpdatePlayer(player);
            return NoContent();
        }

        // DELETE : api/players/5
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id) 
        {
            _playerService.DeletePlayer(id);
            return NoContent();
        }
    }
}
