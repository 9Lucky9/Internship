namespace ReviewAPI.Models
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }
        public int GameId { get; set; }

        public ReviewDTO(int id, string text, double rating, int gameId)
        {
            Id = id;
            Text = text;
            Rating = rating;
            GameId = gameId;
        }
    }
}
