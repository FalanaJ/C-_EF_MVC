namespace AS_Kol_1.Models
{
	public class Position
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		//* - 1..*
		public virtual ICollection<Player>? Players { get; set; }

		//* - 1
		public virtual ICollection<MatchPlayer>? MatchPlayers { get; set; }

	}
}
