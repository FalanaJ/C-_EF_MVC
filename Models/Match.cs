namespace AS_Kol_1.Models
{
	public class Match
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public string? Stadium { get; set; }

		//* - 0..1
		public virtual ICollection<Article>? Articles { get; set; }

		//* - 1
		public virtual ICollection<MatchEvent>? MatchEvents { get; set; }

		//* - 1
		public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }

		//2 - *
		public int? HomeTeamId { get; set; } // Gospodarz
		public virtual Team? HomeTeam { get; set; }

		public int? AwayTeamId { get; set; } // Goście
		public virtual Team? AwayTeam { get; set; }
	}
}
