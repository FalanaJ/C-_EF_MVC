namespace AS_Kol_1.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }

		//* - 1
		public virtual ICollection<Article>? Articles { get; set; }
	}
}
