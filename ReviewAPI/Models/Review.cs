using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewAPI.Models
{
    public class Review
    {
        [Key]
        public int Id { get; private set; }
        public int GameId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public double Rating { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        /// <summary>
        /// Конструктор для EF core
        /// </summary>
        private Review() { }

        public Review(string text, double rating, Game game)
        {
            Text = text;
            Rating = rating;
            Game = game;
        }

    }
}

