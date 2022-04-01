using Microsoft.EntityFrameworkCore;
using ReviewAPI.Models;

namespace ReviewAPI.Repository
{
    public class ReviewRepository : IRepository<ReviewDTO>
    {
        private ApplicationContext _context;

        public ReviewRepository()
        {
            _context = new ApplicationContext(DbContextHelper.GetDbContextOptions());
        }

        /// <summary>
        /// Получить все рецензии
        /// </summary>
        /// <returns>Коллекцию игр</returns>
        public IEnumerable<ReviewDTO> GetAll()
        {
            var reviewsDTO = from review in _context.Reviews
                             select new ReviewDTO(review.Id, review.Text, review.Rating, review.Game.Id);
            return reviewsDTO;
        }

        /// <summary>
        /// Получить рецензию
        /// </summary>
        /// <param name="id">Номер рецензии</param>
        /// <returns>Рецензия</returns>
        public ReviewDTO? Get(int id)
        {
            var review = _context.Reviews.Include(x => x.Game).FirstOrDefault(x => x.Id == id);
            if (review == null)
                return null;
            ReviewDTO reviewDTO = new(review.Id, review.Text, review.Rating, review.Game.Id);
            return reviewDTO;
        }

        /// <summary>
        /// Создать рецензию
        /// </summary>
        /// <param name="item">рецензия</param>
        /// <returns>Результат создания</returns>
        public bool Create(ReviewDTO item)
        {
            var game = _context.Games.Find(item.GameId);
            if (game == null)
                return false;
            Review review = new Review(item.Text, item.Rating, game);
            _context.Reviews.Add(review);
            Save();
            return true;
        }

        /// <summary>
        /// Обновить рецензию
        /// </summary>
        /// <param name="item">Рецензия</param>
        /// <returns>Результат обновления</returns>
        public bool Update(ReviewDTO item)
        {
            var review = _context.Reviews.FirstOrDefault(x => x.Id == item.Id);
            if (review == null)
                return false;
            review.Text = item.Text;
            review.Rating = item.Rating;
            _context.Update(review);
            Save();
            return true;
        }

        /// <summary>
        /// Удалить рецензию
        /// </summary>
        /// <param name="id">Номер рецензии</param>
        /// <returns>Результат удаления</returns>
        public bool Remove(int id)
        {
            var review = _context.Reviews.FirstOrDefault(x => x.Id == id);
            if (review == null)
                return false;
            _context.Reviews.Remove(review);
            Save();
            return true;
        }

        /// <summary>
        /// Получить все рецензии на игру
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public IEnumerable<Review> GetAllReviewsByGame(int gameId)
        {
            var reviews = (from review in _context.Reviews.Include(p => p.Game)
                           where review.Game.Id == gameId
                           select review);
            return reviews;
        }
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
