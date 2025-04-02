namespace AS_Kol_1.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Content { get; set; }

		//1 - *
		public int ArticleId { get; set; }
		public virtual Article? Article { get; set; }
	}
}
