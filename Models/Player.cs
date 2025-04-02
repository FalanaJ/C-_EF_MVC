namespace AS_Kol_1.Models
{
	public class Player
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Country { get; set; }
		public DateTime BirthDate { get; set; }

		//1 - *
		public int? TeamId { get; set; }
		public virtual Team? Team { get; set; }

		//* - 1
		public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }

		//1..* - *
		public virtual ICollection<Position>? Positions { get; set; }
	}
}
