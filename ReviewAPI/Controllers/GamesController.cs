using Microsoft.AspNetCore.Mvc;
using ReviewAPI.Authentication;
using ReviewAPI.Models;
using ReviewAPI.Repository;

namespace ReviewAPI.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {

        private IGame _iGame;

        public GamesController(IGame igame)
        {
            _iGame = igame;
        }

        /// <summary>
        /// Добавить игру
        /// </summary>
        /// <param name="game">игра</param>
        [HttpPost]
        public ActionResult Add([FromBody] Game game)
        {
            if (_iGame.Create(game))
            {
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Получить игру
        /// </summary>
        /// <param name="id">Номер игры</param>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var item = _iGame.Get(id);
            if (item != null)
            {
                return Ok(item);

            }
            return NotFound();
        }

        /// <summary>
        /// Удалить игру
        /// </summary>
        /// <param name="item">игра</param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_iGame.Remove(id))
            {
                return NoContent();

            }
            return NotFound();
        }

        /// <summary>
        /// Обновить игру
        /// </summary>
        /// <param name="item">игра</param>
        [HttpPut]
        public ActionResult Update([FromBody] Game game)
        {
            if (_iGame.Update(game))
            {
                return Ok();

            }
            return NotFound();
        }

        /// <summary>
        /// Получить игру и список всех её рецензий и оценок.
        /// </summary>
        /// <param name="gameId">Номер игры</param>
        [HttpGet("gameAndReviews")]
        public ActionResult GameAndReviews(int gameId)
        {
            return Ok(_iGame.GetGameAndReviews(gameId));
        }

        /// <summary>
        /// Получить все игры в сортировке по оценке по убыванию;
        /// </summary>
        [HttpGet("allByDescending")]
        public ActionResult AllGamesInOrderByDescending()
        {
            return Ok(_iGame.GetGamesByDescendingOrder());
        }
    }
}
