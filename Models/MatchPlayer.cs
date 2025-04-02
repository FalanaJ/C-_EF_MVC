namespace AS_Kol_1.Models
{
	public class MatchPlayer
	{
		public int Id { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		//1 - *
		public int? MatchId { get; set; }
		public virtual Match? Match { get; set; }

		//1 - *
		public int? PositionId { get; set; }
		public virtual Position? Position { get; set; }

		//1 - *
		public int? PlayerId { get; set; }
		public virtual Player? Player { get; set; }

		//* - 0..1
		public virtual ICollection<MatchEvent>? MatchEvents { get; set; }

	}
}
