﻿using Microsoft.AspNetCore.Mvc;
using ReviewAPI.Models;
using ReviewAPI.Repository;

namespace ReviewAPI.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private ReviewRepository _reviewsRepository = new();

        /// <summary>
        /// Добавить рецензию 
        /// </summary>
        /// <param name="review">Рецензия</param>
        [HttpPost]
        public ActionResult Add([FromBody] ReviewDTO review)
        {
            if (_reviewsRepository.Create(review))
                return Ok();
            return NotFound();
        }

        /// <summary>
        /// Получить рецензию по номеру
        /// </summary>
        /// <param name="id">Номер рецензии</param>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var review = _reviewsRepository.Get(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        /// <summary>
        /// Удалить рецензию
        /// </summary>
        /// <param name="id">Номер рецензии</param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_reviewsRepository.Remove(id))
                return NoContent();
            return NotFound();
        }

        /// <summary>
        /// Обновить рецензию
        /// </summary>
        /// <param name="item">Рецензия</param>
        [HttpPut]
        public ActionResult Update([FromBody] ReviewDTO review)
        {
            if (_reviewsRepository.Update(review))
                return Ok();
            return NotFound();
        }

    }
}