namespace AS_Kol_1.Models
{
	public class Team
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Country { get; set; }
		public string? City { get; set; }
		public DateTime? FoundingDate { get; set; }

		//1 - *
		public int? LeagueId { get; set; }
		public virtual League? League { get; set; }

		//* - 1
		public virtual ICollection<Player>? Players { get; set; }

		//* - 2
		public virtual ICollection<Match>? HomeMatches { get; set; }
		public virtual ICollection<Match>? AwayMatches { get; set; }
	}
}
