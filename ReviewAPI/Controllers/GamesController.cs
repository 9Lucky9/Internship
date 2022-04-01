using Microsoft.AspNetCore.Mvc;
using ReviewAPI.Models;
using ReviewAPI.Repository;

namespace ReviewAPI.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        private GameRepository _gameRepository = new();

        [HttpPost]
        public ActionResult Add([FromBody] Game game)
        {
            if (_gameRepository.Create(game))
                return Ok();
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var item = _gameRepository.Get(id);
            if (item != null)
                return Ok(item);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_gameRepository.Remove(id))
                return NoContent();
            return NotFound();
        }

        [HttpPut]
        public ActionResult Update([FromBody] Game game)
        {
            if (_gameRepository.Update(game))
                return Ok();
            return NotFound();
        }

        [HttpGet("gameAndReviews")]
        public ActionResult GameAndReviews(int gameId)
        {
            return Ok(_gameRepository.GetGameAndReviews(gameId));
        }

        [HttpGet("allByDescending")]
        public ActionResult AllGamesInOrderByDescending()
        {
            return Ok(_gameRepository.GetGamesByDescendingOrder());
        }
    }
}
