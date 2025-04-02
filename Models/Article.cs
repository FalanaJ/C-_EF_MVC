namespace AS_Kol_1.Models
{
	public class Article
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Lead {  get; set; }
		public string? Content { get; set; }
		public DateTime CreationDate { get; set; }

		//1 - *
		public int AuthorId { get; set; }
		public virtual Author? Author { get; set; }

		//1 - * (nullable)
		public int? CategoryId { get; set; }
		public virtual Category? Category { get; set; }

		//0..1 - * (nullable)
		public int? MatchId { get; set; }
		public virtual Match? Match { get; set; }

		//* - * (nullable)
		public virtual ICollection<Tag>? Tags { get; set; }

		//* - 1 (nullable)
		public virtual ICollection<Comment>? Comments { get; set; }
	}
}
