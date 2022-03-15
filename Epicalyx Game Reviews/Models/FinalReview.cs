namespace Epicalyx_Game_Reviews.Models
{
    public class FinalReview
    {
        public int FinalReviewID { get; set; }
        public string Review { get; set; }
        public int FinalRating { get; set; }
        public int Genre { get; set; }
        public int Publisher { get; set; }


        public Game Game { get; set; }
        public User User { get; set; }
    }
}