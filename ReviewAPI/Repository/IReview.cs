using ReviewAPI.Models;

namespace ReviewAPI.Repository
{
    public interface IReview
    {
        IEnumerable<ReviewDTO> GetAll();
        ReviewDTO Get(int id);
        bool Create(ReviewDTO item);
        bool Update(ReviewDTO item);
        bool Remove(int id);
    }
}
