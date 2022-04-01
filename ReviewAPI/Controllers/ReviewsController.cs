using Microsoft.AspNetCore.Mvc;
using ReviewAPI.Models;
using ReviewAPI.Repository;

namespace ReviewAPI.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private ReviewRepository _reviewsRepository = new();

        [HttpPost]
        public ActionResult Add([FromBody] ReviewDTO review)
        {
            if (_reviewsRepository.Create(review))
                return Ok();
            return NotFound();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var review = _reviewsRepository.Get(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_reviewsRepository.Remove(id))
                return NoContent();
            return NotFound();
        }

        [HttpPut]
        public ActionResult Update([FromBody] ReviewDTO review)
        {
            if (_reviewsRepository.Update(review))
                return Ok();
            return NotFound();
        }

    }
}
