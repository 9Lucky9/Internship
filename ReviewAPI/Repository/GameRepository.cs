using ReviewAPI.Models;

namespace ReviewAPI.Repository
{
    public class GameRepository : IRepository<Game>
    {
        private ApplicationContext _context;

        public GameRepository()
        {
            _context = new ApplicationContext(DbContextHelper.GetDbContextOptions());
        }

        /// <summary>
        /// Получить все игры
        /// </summary>
        /// <returns>Коллекцию игр</returns>
        public IEnumerable<Game> GetAll()
        {
            return _context.Games;
        }

        /// <summary>
        /// Получить игру
        /// </summary>
        /// <param name="id">Номер игры</param>
        /// <returns>Игра</returns>
        public Game Get(int id)
        {
            return _context.Games.Find(id);
        }

        /// <summary>
        /// Создать игру
        /// </summary>
        /// <param name="item">игра</param>
        /// <returns>Результат создания</returns>
        public bool Create(Game item)
        {
            if (item == null)
            {
                return false;
            }

            _context.Games.Add(item);
            Save();
            return true;
        }

        /// <summary>
        /// Обновить игру
        /// </summary>
        /// <param name="item">игра</param>
        /// <returns>Результат обновления</returns>
        public bool Update(Game item)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == item.Id);
            if (game == null)
            {
                return false;
            }
            _context.Update(item);
            Save();
            return true;
        }

        /// <summary>
        /// Удалить игру
        /// </summary>
        /// <param name="id">Номер игры</param>
        /// <returns>Результат удаления</returns>
        public bool Remove(int id)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return false;
            }

            _context.Games.Remove(game);
            Save();
            return true;
        }

        /// <summary>
        /// Получить игру и её рецензии
        /// </summary>
        /// <param name="gameId">Номер игры</param>
        /// <returns>Игра и коллекция ее рецензий</returns>
        public Tuple<Game, List<ReviewDTO>> GetGameAndReviews(int gameId)
        {
            var game = _context.Games.Find(gameId);
            if (game == null)
            {
                return null;
            }

            var reviews = (from review in _context.Reviews.ToList()
                           where review.GameId == gameId
                           select review).ToList();
            List<ReviewDTO> reviewDTOs = new();
            foreach (var review in reviews)
            {
                reviewDTOs.Add(new ReviewDTO(review.Id, review.Text, review.Rating, review.GameId));
            }
            var tuple = Tuple.Create(game, reviewDTOs);
            return tuple;
        }

        /// <summary>
        /// Получить все игры в убывающем порядке по оценке
        /// </summary>
        /// <returns>Коллекцию игр</returns>
        public List<Game> GetGamesByDescendingOrder()
        {
            List<Tuple<double, Game>> gamesScores = new();
            foreach (var game in _context.Games.ToList())
            {
                var reviews = GetReviewsOnGame(game.Id);
                if (!reviews.Any())
                {
                    continue;
                }

                var tuple = Tuple.Create(GetGameAverageScore(reviews), game);
                gamesScores.Add(tuple);
            }
            var result = gamesScores.OrderByDescending(game => game.Item1);
            List<Game> games = result.ToList().ConvertAll(t => t.Item2);
            return games;
        }

        /// <summary>
        /// Получить средную оценку игры по резенциям
        /// </summary>
        /// <param name="gameId">Номер игры</param>
        /// <returns>Средняя оценка</returns>
        private double GetGameAverageScore(List<Review> reviews)
        {
            return reviews.Average(x => x.Rating);
        }

        private List<Review> GetReviewsOnGame(int gameId)
        {
            var filteredReviews = from review in _context.Reviews
                                  where review.Game.Id == gameId
                                  select review;
            if(!filteredReviews.Any())
            {
                return new List<Review>();
            }

            return filteredReviews.ToList();
        }

        /// <summary>
        /// Сохранение изменений в базе данных
        /// </summary>
        private void Save()
        {
            _context.SaveChanges();
        }
    }
}
