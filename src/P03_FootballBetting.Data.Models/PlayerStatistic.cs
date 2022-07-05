namespace P03_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    //Mapping class -> ONE
    public class PlayerStatistic
    {
        //TODO: Define composite PK in Fluent API
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public byte ScoredGoals { get; set; }

        public byte Assists { get; set; }

        public byte MinutesPlayed { get; set; }
    }
}
