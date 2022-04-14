using ReviewAPI.Models;

namespace ReviewAPI.Repository
{
    public interface IGame
    {
        IEnumerable<Game> GetAll();
        Game Get(int id);
        bool Create(Game item);
        bool Update(Game item);
        bool Remove(int id);

        public Tuple<Game, List<ReviewDTO>> GetGameAndReviews(int gameId);
        public List<Game> GetGamesByDescendingOrder();
    }
}
