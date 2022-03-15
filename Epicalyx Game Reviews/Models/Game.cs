namespace Epicalyx_Game_Reviews.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string AgeRating { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int ReleaseYear { get; set; }

        public ICollection<FinalReview> FinalReview { get; set; }
    }
}
