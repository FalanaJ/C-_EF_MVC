namespace AS_Kol_1.Models
{
	public class EventType
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		//* - 1
		public virtual ICollection<MatchEvent>? MatchEvents { get; set; }

	}
}
