﻿namespace AS_Kol_1.Models
{
	public class Tag
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		//* - *
		public virtual ICollection<Article>? Articles { get; set; }
	}
}
