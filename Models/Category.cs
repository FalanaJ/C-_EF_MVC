namespace AS_Kol_1.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		//* - 1
		public virtual ICollection<Article>? Articles { get; set; }

	}
}
