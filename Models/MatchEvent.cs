namespace AS_Kol_1.Models
{
	public class MatchEvent
	{
		public int Id { get; set; }
		public int Minute { get; set; }

		//1 - *
		public int? MatchId { get; set; }
		public virtual Match? Match { get; set; }

		//1 - *
		public int? EventTypeId { get; set; }
		public virtual EventType? EventType { get; set; }

		//0..1 - *
		public int? MatchPlayerId { get; set; }
		public virtual MatchPlayer? MatchPlayer { get; set; }
	}
}
